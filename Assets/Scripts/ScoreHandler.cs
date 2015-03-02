using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {

	// Use this for initialization
    void Awake()
    {
        Text scoreGUI = GameObject.Find("Score").GetComponent<Text>();
        scoreGUI.text = "SCORE: " + GameData.getScore(); ;
	}
}
