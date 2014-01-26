using UnityEngine;
using System.Collections;

public class Platform2D : MonoBehaviour {
	
	public GameColor2D color;
	public float speed;
	public float size;
	private System.Random r = new System.Random();
	public static GameObject obj;
	
	// Use this for initialization
	void Start () {
		obj = GameObject.Find("gameDataContainer2D");
		resetPlatform();
	}
	
	public void resetPlatform()
	{
		size = 10 + Random.value * 10;
		gameObject.transform.localScale = new Vector3(size , 2, 1);
		(gameObject.collider2D as BoxCollider2D).size.Set(size, 2);
		//gameObject.collider.transform.localScale = new Vector3(size , 1, 0);
		
		switch(Mathf.FloorToInt(Random.value * 5))
		{
		case 1:
			color = GameColor2D.red;
			break;
		case 2:
			color = GameColor2D.blue;
			break;
		case 3:
			color = GameColor2D.green;
			break;
		case 4:
			color = GameColor2D.yellow;
			break;
		default:
			color = GameColor2D.purple;
			break;
		}
		
		gameObject.renderer.material = color.textureMaterial;
	}
	
	// Update is called once per frame
	void Update () {

		rigidbody2D.transform.position += new Vector3(-(obj.GetComponent<GameData>().gameSpeed) * Time.deltaTime, 0,0);
	}
}
