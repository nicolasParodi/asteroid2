using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject MainMenuButton;
    public GameObject RestartButton;
    public GameObject ExitButton;
    public GameObject playShip;
    public GameObject asteroids;
    public GameObject gameOver;
    public GameObject scoreText;
    public string nombreEscena;

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
                scoreText.GetComponent<GameScore>().Score = 0;
                RestartButton.SetActive(false);
                MainMenuButton.SetActive(false);
                ExitButton.SetActive(false);
                playShip.GetComponent<PlayerController>().Init();
                asteroids.GetComponent<AsteroidsSpawn>().Init();
                break;

            case GameManagerState.GameOver:
                asteroids.GetComponent<AsteroidsSpawn>().Stop();
                gameOver.SetActive(true);
                Invoke("ChangeToRestartState", 2.5f); //cambiar a restart case
                break;

            case GameManagerState.Restart:
                gameOver.SetActive(false);
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
