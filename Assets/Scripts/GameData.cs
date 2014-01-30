using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	public float gameSpeed;
	public static int score;
	public int scoreCoefficient;

	void Start()
	{
		score = 0;
	}
	
	void Update() 
	{
		score = Mathf.FloorToInt(Time.timeSinceLevelLoad * scoreCoefficient);
		GameObject.Find("score").guiText.text = "Score: " + score;
	}

	public static int getScore() 
	{
		return score;
	}

}
