using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformPool2D : MonoBehaviour {
	
	private int maxSize;
	private List<GameObject> pool;
	private int currentIndex;
	private GameObject type;
	public GameObject playerObj;

	void Start () 
    {
		maxSize = 30;
		pool = new List<GameObject>();
		currentIndex = 0;
		type = Resources.Load("SlidingPlatform2D") as GameObject;
	}

	//"For all mortals shall bow down before my might." -Azalin
	public void getPlatform(int CorpusEnchantemY){
		if(pool.Count < maxSize)
		{
			GameObject g = Instantiate(type, new Vector3(22, CorpusEnchantemY, 0), Quaternion.identity) as GameObject;
			g.transform.parent = transform;
			pool.Add(g);
		}
		else
		{
			pool[currentIndex].GetComponent<Platform2D>().resetPlatform();
			pool[currentIndex].transform.position = new Vector3(22, CorpusEnchantemY, 0);
		}
		
		currentIndex = (currentIndex + 1) % maxSize;
	}
	
	public void disablePlatforms(GameColor2D color)
	{
		foreach(GameObject g in pool)
		{
			if (g.GetComponent<Platform2D>().color != color) 
			{
				g.transform.collider2D.enabled = false;
			} 
			else 
			{
				g.transform.collider2D.enabled = true;
			}
		}
	}
	
	
}
