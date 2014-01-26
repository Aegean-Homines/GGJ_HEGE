using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformCreator2D : MonoBehaviour {
	
	public GameObject platform;
	private List<GameObject> objectArray = new List<GameObject>();
	private int randomNumber, oldRandom;
	private float lastTime;
	public float threshold = 2.0f;
	public int counter;
	// Use this for initialization
	void Start () {
		lastTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - lastTime > threshold)
		{
			oldRandom = Mathf.FloorToInt((Random.value*8 - 4));
			randomNumber = Mathf.FloorToInt((Random.value*4 - 2));
			
			if(oldRandom == randomNumber)
			{
				gameObject.GetComponent<PlatformPool2D>().getPlatform(randomNumber);
			}
			else
			{
				gameObject.GetComponent<PlatformPool2D>().getPlatform(randomNumber);
				gameObject.GetComponent<PlatformPool2D>().getPlatform(oldRandom);
			}
			lastTime = Time.time;
			
			counter++;
			if (counter == 8)
			{
				counter = 0;
				gameObject.GetComponent<GameData>().gameSpeed += 1;
				threshold -= (threshold / 10);
				GameObject.Find("Playah").GetComponent<Player2D>().speed += 0.8f;
			}
		}
		
	}
}
