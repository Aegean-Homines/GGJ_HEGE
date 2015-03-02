using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameData : MonoBehaviour {

	public float gameSpeed;
	public static int score;
	public static int highScore;
	public int scoreCoefficient;

    private Text scoreGUI;
    private Text highScoreGUI;

    void Awake()
    {
        scoreGUI = GameObject.Find("Score").GetComponent<Text>();
        highScoreGUI = GameObject.Find("High Score").GetComponent<Text>();

        score = 0;
        if (PlayerPrefs.HasKey("High Score"))
            highScore = PlayerPrefs.GetInt("High Score");
        else
            PlayerPrefs.SetInt("High Score", 0);
    }

	void Update() 
	{
		score = Mathf.FloorToInt(Time.timeSinceLevelLoad * scoreCoefficient);
        scoreGUI.text = "Score: " + score;
        highScoreGUI.text = "High Score: " + (highScore > score ? highScore : score);
	}

	public static int getScore() 
	{
		return score;
	}

}
