using UnityEngine;
using System.Collections;

public class ScoreHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find("score").guiText.text = "SCORE: " + GameData.getScore();
	}
}
