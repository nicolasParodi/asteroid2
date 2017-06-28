using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour {

    Text scoreTextUI;
    Text highScoreTextUI;


	void Start () 
	{
        scoreTextUI = GameObject.FindGameObjectWithTag("ScoreTextTag").GetComponent<Text>();
        highScoreTextUI = GameObject.FindGameObjectWithTag("HighScoreTextTag").GetComponent<Text>();
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
