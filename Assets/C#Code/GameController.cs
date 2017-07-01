using UnityEngine;
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
    }

    GameManagerState GMState;

    void Start()
    {
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
                gameOver.SetActive(true);
                Invoke("ChangeToRestartState", 2.5f);
                if (GameData.score > GameData.highScore)
                {
                    GameData.highScore = GameData.score;
                    score.UpdateHighScoreTextUI();
                }
                break;

            case GameManagerState.Restart:
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

    public void ChangeToRestartState()
    {
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
