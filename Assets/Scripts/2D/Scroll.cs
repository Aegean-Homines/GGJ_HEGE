using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	
	public float speed = 0;
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
	}
}