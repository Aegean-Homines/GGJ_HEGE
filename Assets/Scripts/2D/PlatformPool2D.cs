using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformPool2D : MonoBehaviour {
	
	private int maxSize;
	private List<GameObject> pool;
	private int currentIndex;
	private GameObject type;
	public GameObject playerObj;
	// Use this for initialization
	void Start () {
		
		Debug.Log("Pool Start");
		maxSize = 30;
		pool = new List<GameObject>();
		currentIndex = 0;
		type = Resources.Load("SlidingPlatform2D") as GameObject;
	}

	//"For all mortals shall bow down before my might." -Azalin
	public void getPlatform(int CorpusEnchantemY){
		if(pool.Count < maxSize)
		{
			Debug.Log ("Pool < maxSize");
			GameObject g = Instantiate(type, new Vector3(15, CorpusEnchantemY, 0),Quaternion.identity) as GameObject;
			g.transform.parent = transform;
			pool.Add(g);
		}
		else
		{
			Debug.Log ("Pool normal path");
			pool[currentIndex].GetComponent<Platform2D>().resetPlatform();
			pool[currentIndex].transform.position = new Vector3(15/*+playerObj.GetComponent<Player2D>().rigidbody2D.velocity.magnitude*/,CorpusEnchantemY,0);
		}
		
		currentIndex = (currentIndex + 1) % maxSize;
	}
	
	public void disablePlatforms(GameColor2D color)
	{
		foreach(GameObject g in pool)
		{
			if (g.GetComponent<Platform2D>().color != color) 
			{
				/*g.transform.localScale = new Vector3(g.transform.localScale.x, g.transform.localScale.y, 0.01f);
				var col = g.collider as BoxCollider;
				(g.collider as BoxCollider).size = new Vector3(col.size.x, col.size.y, 0.01f);*/
				
				//g.transform.localPosition = new Vector3(g.transform.localPosition.x, g.transform.localPosition.y, 3);
				g.transform.collider2D.enabled = false;
			} 
			else 
			{
				/*g.transform.localScale = new Vector3(g.transform.localScale.x
				                                     , g.transform.localScale.y
				                                     , 1.0f);
				var col = g.collider as BoxCollider;
				(g.collider as BoxCollider).size = new Vector3(col.size.x, col.size.y, 1.0f);*/
				//g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, 0);
				g.transform.collider2D.enabled = true;
			}
		}
	}
	
	
}
