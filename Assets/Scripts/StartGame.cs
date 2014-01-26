using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	// Update is called once per frame
	void OnMouseDown(){
		Debug.Log("tikladim");
		Application.LoadLevel("DegistirmedenOnce");
	}
}
