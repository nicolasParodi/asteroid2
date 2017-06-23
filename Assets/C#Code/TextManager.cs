using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public static int lives = 5;
	public int score = 0;

	public static Text livesText;
	public Text scoreText;

	public static void LoseLife(int losedL){
		lives += losedL;
		if (lives <= 0) {
			GameOver();
		}
	}

	public static void GameOver(){
		Debug.Log ("Game Over");
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	void Update(){
		scoreText.text = "Score: " + score.ToString ();
		livesText.text = "Lives: " + lives.ToString ();
		
	}

}
