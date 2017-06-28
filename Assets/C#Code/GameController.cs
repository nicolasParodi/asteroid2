using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    GameObject highScoreUI;
    public GameObject MainMenuButton;
    public GameObject RestartButton;
    public GameObject ExitButton;
    public GameObject highScore;
    public GameObject playShip;
    public GameObject asteroids;
    public GameObject gameOver;
    GameScore scoreText;
    GameScore highScoreText;
    public string nombreEscena;
    bool active = false;
    int score;

    public enum GameManagerState
    {
        MainMenu,
        Gameplay,
        GameOver,
        Restart,
    }

    GameManagerState GMState;

    void Start()
    {
        highScoreUI = GameObject.FindGameObjectWithTag("HighScoreimage").GetComponent<GameObject>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<GameScore>();
        highScoreText = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<GameScore>();
        Time.timeScale = (active) ? 0 : 1f;
        GMState = GameManagerState.Gameplay;
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.MainMenu:
                SceneManager.LoadScene(nombreEscena);
                break;
            case GameManagerState.Gameplay:
                highScoreUI.SetActive(false);
                GameData.score = 0;
                scoreText.UpdateScoreTextUI();
                highScore.SetActive(false);
                RestartButton.SetActive(false);
                MainMenuButton.SetActive(false);
                ExitButton.SetActive(false);
                playShip.GetComponent<PlayerController>().Init();
                asteroids.GetComponent<AsteroidsSpawn>().Init();
                break;

            case GameManagerState.GameOver:
                asteroids.GetComponent<AsteroidsSpawn>().Stop();
                gameOver.SetActive(true);
                Invoke("ChangeToRestartState", 2.5f);
                if (GameData.score > GameData.highScore) GameData.highScore = GameData.score;
                highScoreText.UpdateHighScoreTextUI();
                break;

            case GameManagerState.Restart:
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

    public void ActivateButton(GameObject button)
    {
        button.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
