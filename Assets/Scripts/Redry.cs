using UnityEngine;
using System.Collections;

public class Redry : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel("DegistirmedenOnce");
		}
	}

	// Update is called once per frame
	void OnMouseDown(){
		Application.LoadLevel("DegistirmedenOnce");
	}
}
