﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   public  GameObject highScoreUI;
    public GameObject MainMenuButton;
    public GameObject RestartButton;
    public GameObject ExitButton;
    public GameObject highScore;
    public GameObject playShip;
    public GameObject asteroids;
    public GameObject gameOver;
    public GameScore score;
    public AudioClip gameMusic;
    bool active = false;

    public enum GameManagerState
    {
        MainMenu,
        HowToPlay,
        Settings,
        Gameplay,
        GameOver,
        Restart,
        Re_Play,
    }

    GameManagerState GMState;

    void Start()
    {
        score.RestartScore();
        AudioManager.instance.PlayMusic(gameMusic, 2);
        Cursor.visible = false;
        highScoreUI.GetComponent<GameObject>();
        score.GetComponent<GameScore>();
        Time.timeScale = (active) ? 0 : 1f;
        GMState = GameManagerState.Gameplay;
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.MainMenu:
                Cursor.visible = true;
                SceneManager.LoadScene("Main Menu");
                break;

            case GameManagerState.HowToPlay:
                Cursor.visible = true;
                SceneManager.LoadScene("How to Play");
                break;

            case GameManagerState.Settings:
                Cursor.visible = true;
                SceneManager.LoadScene("Settings");
                break;

            case GameManagerState.Gameplay:
                Cursor.visible = false;
                score.RestartScore();
                highScoreUI.SetActive(false);
                DissableButton(RestartButton);
                DissableButton(MainMenuButton);
                DissableButton(ExitButton);
                playShip.GetComponent<PlayerController>().Init();
                asteroids.GetComponent<AsteroidsSpawn>().Init();
                break;

            case GameManagerState.GameOver:
                asteroids.GetComponent<AsteroidsSpawn>().Stop();
                GameObject laserGO = GameObject.FindWithTag("Laser");
                if (laserGO != null)
                {
                    ArmaDelJugador laser = laserGO.GetComponent<ArmaDelJugador>();
                    laser.DesactivarLasers();
                }
                gameOver.SetActive(true);
                Invoke("ChangeToRePlaytState", 2.5f);
                if (GameData.score > GameData.highScore)
                {
                    GameData.highScore = GameData.score;
                    score.UpdateHighScoreTextUI();
                }
                break;

            case GameManagerState.Restart:
                Time.timeScale = (false) ? 0 : 1f;
                Cursor.visible = false;
                break;

            case GameManagerState.Re_Play:
                Cursor.visible = true;
                gameOver.SetActive(false);
                highScore.SetActive(true);
                ActivateButton(RestartButton);
                ActivateButton(MainMenuButton);
                ActivateButton(ExitButton);
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToRePlaytState()
    {
        SetGameManagerState(GameManagerState.Re_Play);
    }

    public void ChangeToRestartState()
    {
        score.RestartScore();
        SetGameManagerState(GameManagerState.Restart);
    }

    public void GameOver()
    {
        SetGameManagerState(GameManagerState.GameOver);
    }

    public void ChangeToMainMenu()
    {
        SetGameManagerState(GameManagerState.MainMenu);
    }

    public void ChangeToHowToPlay()
    {
        SetGameManagerState(GameManagerState.HowToPlay);
    }

    public void ChangeToSettings()
    {
        SetGameManagerState(GameManagerState.Settings);
    }

    public void ActivateButton(GameObject button)
    {
        button.SetActive(true);
    }

    public void DissableButton(GameObject button)
    {
        button.SetActive(false);
    }
}
