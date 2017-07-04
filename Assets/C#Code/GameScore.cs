using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour {

    public Text scoreTextUI;
    public Text highScoreTextUI;
    public static GameScore instance;
    int highScore;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            if (scoreTextUI != null)
            {
                scoreTextUI.GetComponent<Text>();
            }
            highScoreTextUI.GetComponent<Text>();

            highScore = PlayerPrefs.GetInt("high Score Text UI");
            UpdateHighScoreTextUI();
        }
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
        string highScoreStr = string.Format("{0:0000000}", GameData.highScore);
        highScoreTextUI.text = highScoreStr;
        PlayerPrefs.SetInt("high Score Text UI", GameData.highScore);
        PlayerPrefs.Save();
    }
}
