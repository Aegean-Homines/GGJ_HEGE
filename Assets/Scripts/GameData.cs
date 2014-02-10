using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	public float gameSpeed;
	public static int score;
	public static int highScore;
	public int scoreCoefficient;

	void Start()
	{
		score = 0;
		if(PlayerPrefs.HasKey("High Score"))
			highScore = PlayerPrefs.GetInt("High Score");
		else
			PlayerPrefs.SetInt("High Score", 0);
	}
	
	void Update() 
	{
		score = Mathf.FloorToInt(Time.timeSinceLevelLoad * scoreCoefficient);
		GameObject.Find("score").guiText.text = "Score: " + score;
		GameObject.Find ("highscore").guiText.text = "Highscore: " + highScore;
	}

	public static int getScore() 
	{
		return score;
	}

}
