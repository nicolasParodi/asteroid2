using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    
    public enum AudioChanel {Master, Sfx, Music};

    float masterVolumePercent = 1;
    float sfxVolumePrecent = 1;
    float musicVolumePercent = 1;

    AudioSource[] musicSouces;
    int activeMusicSourceIndex;

    public static AudioManager instance;

    Transform audiListener;
    Transform playerT;

    SoundLibrary library;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        library = GetComponent<SoundLibrary>();

        musicSouces = new AudioSource[2];
        for (int i =0; i < 2; i++)
        {
            GameObject newMusicSource = new GameObject("Music source" + (i + 1));
            musicSouces[i] = newMusicSource.AddComponent<AudioSource>();
            newMusicSource.transform.parent = transform;
        }
        audiListener = FindObjectOfType<AudioListener>().transform;
        playerT = FindObjectOfType<PlayerController>().transform;

        masterVolumePercent = PlayerPrefs.GetFloat("master vol", masterVolumePercent);
        sfxVolumePrecent = PlayerPrefs.GetFloat("sx vol", sfxVolumePrecent);
        musicVolumePercent = PlayerPrefs.GetFloat("music vol", musicVolumePercent);
    }

    void Update()
    {
        if (playerT != null)
        {
            audiListener.position = playerT.position;
        }
    }

    public void SetVolume(float volumePercent, AudioChanel channel)
    {
        switch (channel)
        {
            case AudioChanel.Master:
                masterVolumePercent = volumePercent;
                break;
            case AudioChanel.Sfx:
                sfxVolumePrecent= volumePercent;
                break;
            case AudioChanel.Music:
                musicVolumePercent = volumePercent;
                break;
        }

        musicSouces[0].volume = musicVolumePercent * masterVolumePercent;
        musicSouces[1].volume = musicVolumePercent * masterVolumePercent;

        PlayerPrefs.SetFloat("master vol", masterVolumePercent);
        PlayerPrefs.SetFloat("sx vol", sfxVolumePrecent);
        PlayerPrefs.SetFloat("music vol", musicVolumePercent);
    }

    public void PlayMusic(AudioClip clip, float fadeDuration = 1)
    {
        activeMusicSourceIndex = 1 - activeMusicSourceIndex;
        musicSouces[activeMusicSourceIndex].clip = clip;
        musicSouces[activeMusicSourceIndex].Play();

        StartCoroutine(AnimateMusicCrossfade(fadeDuration));
    }

    public void PlaySound(AudioClip clip, Vector3 pos)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos, sfxVolumePrecent * masterVolumePercent);
        }
    }

    public void PlaySound(string soundName, Vector3 pos)
    {
        PlaySound(library.GetClipFromName(soundName), pos);
    }

    IEnumerator AnimateMusicCrossfade(float duration)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / duration;
            musicSouces[activeMusicSourceIndex].volume = Mathf.Lerp(0, musicVolumePercent * masterVolumePercent, percent);
            musicSouces[1-activeMusicSourceIndex].volume = Mathf.Lerp(musicVolumePercent * masterVolumePercent,0, percent);
            yield return null;
        }
    }
}
