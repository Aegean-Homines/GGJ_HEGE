using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformCreator : MonoBehaviour {
	
	public GameObject platform;
	private List<GameObject> objectArray = new List<GameObject>();
	private int randomNumber, oldRandom;
	private float lastTime;
	public float threshold = 2;
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
			/*if(objectArray.Count == 0)
			{
				objectArray.Add(Instantiate(platform, new Vector3(1, 0, 0), Quaternion.identity) as GameObject);
			}
			else
			{
				var randPos = Random.insideUnitCircle * 3;
				Debug.Log("Before abs:" + randPos);
				objectArray.Add(Instantiate(platform,
				                            objectArray[objectArray.Count - 1].transform.position
				                            + new Vector3(Mathf.Abs(randPos.x), randPos.y, 0),
				                            Quaternion.identity) as GameObject);
				Debug.Log("size first:" + objectArray[objectArray.Count - 1].gameObject.GetComponent<Platform>().getSize());
				objectArray[objectArray.Count - 1].transform.position += new Vector3((objectArray[objectArray.Count - 1].gameObject.GetComponent<Platform>().size
				                                                                      + objectArray[objectArray.Count - 2].transform.localScale.x  ) / 2,0,0);
				Debug.Log("onceki: " + objectArray[objectArray.Count - 1].transform.position
				          + "\nsonraki: " + objectArray[objectArray.Count - 2].transform.position);
				Debug.Log("size second:" + objectArray[objectArray.Count - 1].gameObject.GetComponent<Platform>().getSize());
			}*/

			if(oldRandom == randomNumber)
				gameObject.GetComponent<PlatformPool>().getPlatform(randomNumber);
			else
			{
				gameObject.GetComponent<PlatformPool>().getPlatform(randomNumber);
				gameObject.GetComponent<PlatformPool>().getPlatform(oldRandom);
			}
			lastTime = Time.time;
			for(int i = 0; i < objectArray.Count; i++)
			{
				Debug.Log("objectArray["+i+"]: " + objectArray[i]);
			}
		}

	}
}
