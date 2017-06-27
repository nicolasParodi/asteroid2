using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour {

	public Text scoreTextUI;
    //public Text highScoreText;

    int score;
    string higScoreStr;


    public int Score
	{
		get
		{
			return this.score;
		}
		set
		{
			this.score = value;
			UpdateScoreTextUI ();
		}
	}

	// Use this for initialization
	void Start () 
	{
		scoreTextUI = GetComponent<Text> ();
        //highScoreText = GetComponent<Text>();
        //highScoreText.text = higScoreStr;
    }
	
	// Update is called once per frame
	void UpdateScoreTextUI ()
	{
		string scoreStr = string.Format ("{0:0000000}", score);
		scoreTextUI.text = scoreStr;
       /* if (score> PlayerPrefs.GetInt("HighScoreTextTag", 0))
        {
            PlayerPrefs.SetInt("HighScoreTextTag", score);
            higScoreStr = string.Format("{0:0000000}", score);
        }*/
	}
}
