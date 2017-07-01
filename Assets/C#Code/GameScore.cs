using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour {

    public Text scoreTextUI;
    public Text highScoreTextUI;


	void Start () 
	{
        scoreTextUI.GetComponent<Text>();
        highScoreTextUI.GetComponent<Text>(); 
    }

    public void RestartScore()
    {
        GameData.score = 0;
        UpdateScoreTextUI();
    }


    public void UpdateScoreTextUI ()
	{
		string scoreStr = string.Format ("{0:0000000}", GameData.score);
		scoreTextUI.text = scoreStr;
	}

    public void UpdateHighScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000000}", GameData.highScore);
        highScoreTextUI.text = scoreStr;
    }
}
