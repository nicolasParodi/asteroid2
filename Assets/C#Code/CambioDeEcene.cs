using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEcene : MonoBehaviour {

    public GameObject playButton;
    public GameObject howToPlayButton;
    public GameObject exitButton;
    public GameObject mainMenuButton;

	public void CambiarEscena (string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void ScreenMainMenu()
    {
        playButton.SetActive(true);
        howToPlayButton.SetActive(true);
        exitButton.SetActive(true);
        mainMenuButton.SetActive(false);
    }

    public void ScreenHowToPlay()
    {
        playButton.SetActive(false);
        howToPlayButton.SetActive(false);
        exitButton.SetActive(false);
        mainMenuButton.SetActive(true);
    }

}
