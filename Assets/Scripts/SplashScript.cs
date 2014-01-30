using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > 30 || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
			Application.LoadLevel("MainMenu");
	}
}
