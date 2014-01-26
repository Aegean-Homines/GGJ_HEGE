using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	public float gameSpeed;
	public static int score;

	void Start()
	{
		score = 0;
	}
	
	void Update() 
	{
		score++;
		GameObject.Find("score").guiText.text = "Score: " + score;
	}

	public static int getScore() 
	{
		return score;
	}

}
