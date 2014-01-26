using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformPool : MonoBehaviour {

	private int maxSize;
	private List<GameObject> pool;
	private int currentIndex;
	private GameObject type;
	// Use this for initialization
	void Start () {
	
		Debug.Log("Pool Start");
		maxSize = 20;
		pool = new List<GameObject>();
		currentIndex = 0;
		type = Resources.Load("SlidingPlatform") as GameObject;
	}

	public void getPlatform(int CorpusEnchantemY){
		if(pool.Count < maxSize)
		{
			Debug.Log ("Pool < maxSize");
			pool.Add(Instantiate(type, new Vector3(15,CorpusEnchantemY,0),Quaternion.identity)as GameObject);
		}
		else
		{
			Debug.Log ("Pool normal path");
			pool[currentIndex].GetComponent<Platform>().resetPlatform();
			pool[currentIndex].transform.position = new Vector3(15,CorpusEnchantemY,0);
		}

		currentIndex = (currentIndex + 1) % maxSize;
	}

	public void disablePlatforms(GameColor color)
	{
		foreach(GameObject g in pool)
		{
			if (g.GetComponent<Platform>().color != color) 
			{
				/*g.transform.localScale = new Vector3(g.transform.localScale.x, g.transform.localScale.y, 0.01f);
				var col = g.collider as BoxCollider;
				(g.collider as BoxCollider).size = new Vector3(col.size.x, col.size.y, 0.01f);*/

				g.transform.localPosition = new Vector3(g.transform.localPosition.x, g.transform.localPosition.y, 3);
			} 
			else 
			{
				/*g.transform.localScale = new Vector3(g.transform.localScale.x
				                                     , g.transform.localScale.y
				                                     , 1.0f);
				var col = g.collider as BoxCollider;
				(g.collider as BoxCollider).size = new Vector3(col.size.x, col.size.y, 1.0f);*/
				g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, 0);
			}
		}
	}


}
