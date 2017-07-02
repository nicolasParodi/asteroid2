using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SemiControler : MonoBehaviour {


    public AudioClip menuMusic;

    void Start()
    {
        AudioManager.instance.PlayMusic(menuMusic, 2);
    }

    public void Play()
    {
        SceneManager.LoadScene("Navecita");
    }
}
