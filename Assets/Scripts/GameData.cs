using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameData : MonoBehaviour {

	public float gameSpeed;
	public static int score;
	public static int highScore;
	public int scoreCoefficient;

    public static int difficulty;

    void Awake()
    {
        difficulty = 2;
        score = 0;
        if (PlayerPrefs.HasKey("High Score"))
            highScore = PlayerPrefs.GetInt("High Score");
        else
            PlayerPrefs.SetInt("High Score", 0);
    }

	void Update() 
	{
		score = Mathf.FloorToInt(Time.timeSinceLevelLoad * scoreCoefficient);
        highScore = highScore > score ? highScore : score;
	}
}
