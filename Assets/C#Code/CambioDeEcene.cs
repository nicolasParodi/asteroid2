using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioDeEcene : MonoBehaviour {

    public GameObject howToPlayHolder;
    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;

    public Slider[] volumeSliders;
    public Toggle[] resolutionToggles;
    public int[] screenWidths;
    int activeScreenResIndex;

   void Start()
    {
        
    }

    public void Play ()
    {
        SceneManager.LoadScene("Navecita");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void ScreenMainMenu()
    {
        mainMenuHolder.SetActive(true);
        howToPlayHolder.SetActive(false);
        optionsMenuHolder.SetActive(false);
    }

    public void ScreenHowToPlay()
    {
        mainMenuHolder.SetActive(false);
        howToPlayHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }

    public void ScreenSettings()
    {
        mainMenuHolder.SetActive(false);
        howToPlayHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
    }

    public void SetScreenResolution (int i)
    {
        if (resolutionToggles[i].isOn)
        {
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
            PlayerPrefs.SetInt("screen res index", activeScreenResIndex);
            PlayerPrefs.Save();
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        for(int i=0 ; i < resolutionToggles.Length ; i++)
        {
            resolutionToggles [i].interactable = !isFullscreen;
        }

        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolutions = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolutions.width, maxResolutions.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }
        PlayerPrefs.SetInt("fullscreen", ((isFullscreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

    public void SetMasterVolume (float value)
    {
       // AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void SetMusicVolume(float value)
    {
       // AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }

    public void SetSfxVolume(float value)
    {
        //AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }
}
