using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pun : MonoBehaviour {
	private string[] puns = {
		"Stewie's telephone was ringing,\n he pinked up and said 'Yellow?'",
		"I have cyan all kinds of colors!",
		"You are really colorful, orange you?",
		"Stewie was the black sheep of the family,\n even though he was the most colorful.",
		"Stewie started reading a yellow book.\n When he finished the whole book, it was all red.",
		"Stewie saw a sad square and\n asked her 'Are you feeling blue?'"
	};

	private float lastTime = 0;
	// Use this for initialization
	void Start () {
		guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if ((GameData.score + 1) % 2000 == 0)
		{
			guiText.text = puns[Mathf.FloorToInt(Random.value*(6))];
			lastTime = Time.time;
		}

		if(Time.time - lastTime > 5)
			guiText.text = "";
	}
}
