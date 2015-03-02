using UnityEngine;
using System.Collections;

public class Redry : MonoBehaviour 
{
	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel("DegistirmedenOnce");
		}
	}

	public void OnClick(){
		Application.LoadLevel("DegistirmedenOnce");
	}
}
