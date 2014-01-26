using UnityEngine;
using System.Collections;

public class FirstBlock2D : MonoBehaviour {
	public GameObject obj;

	void Start(){
		obj = GameObject.Find("gameDataContainer2D");
	}
	// Update is called once per frame
	void Update () {
		rigidbody2D.transform.position += new Vector3(-(obj.GetComponent<GameData>().gameSpeed) * Time.deltaTime, 0,0);
	}
}
