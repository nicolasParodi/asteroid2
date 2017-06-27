using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public GameObject playButton;
	public GameObject playShip;
	public GameObject asteroids;
	public GameObject gameOver;
	public GameObject scoreText;

	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,
        Restart,
	}

	GameManagerState GMState;

	void Start ()
	{
		GMState = GameManagerState.Opening;
	}

	void UpdateGameManagerState ()
	{
		switch (GMState)
		{
		case GameManagerState.Opening:
			gameOver.SetActive (false);
            //RestartButton.SetActive(false);
            //ExitButton.SetActive(true);
            playButton.SetActive (true);
			break;
		case GameManagerState.Gameplay:
			scoreText.GetComponent<GameScore> ().Score = 0;
			playButton.SetActive (false);
            //RestartButton.SetActive(false);
            //ExitButton.SetActive(false);
            playShip.GetComponent<PlayerController> ().Init ();
			asteroids.GetComponent<AsteroidsSpawn> ().Init ();
			break;

		case GameManagerState.GameOver:
			asteroids.GetComponent<AsteroidsSpawn> ().Stop ();
			gameOver.SetActive (true);
            Invoke("ChangeToOpeningState", 2.5f); //cambiar a restart case
			break;

        case GameManagerState.Restart:
             gameOver.SetActive(false);
             //RestartButton.SetActive(true);
             //ExitButton.SetActive(true);
             break;
        }
	}

	public void SetGameManagerState(GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState ();
	}

	public void StartGamePlay ()
	{
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState ();
	}

	public void ChangeToOpeningState()
	{
		SetGameManagerState (GameManagerState.Opening);
	}

	public void GameOver()
	{
		SetGameManagerState (GameManagerState.GameOver);
	}

}
