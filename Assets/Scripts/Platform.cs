using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public GameColor color;
    public float speed;
	public float size;

	// Use this for initialization
	void Start () {
		resetPlatform();
	}

	public void resetPlatform()
	{
		size = 2 + Random.value * 4;
		gameObject.transform.localScale = new Vector3(size , 1, 1);
		(gameObject.collider as BoxCollider).size.Set(size , 1, 1);
		//gameObject.collider.transform.localScale = new Vector3(size , 1, 0);
		
		
		switch(Mathf.FloorToInt(Random.value * 5))
		{
		case 1:
			color = GameColor.red;
			break;
		case 2:
			color = GameColor.blue;
			break;
		case 3:
			color = GameColor.green;
			break;
		case 4:
			color = GameColor.yellow;
			break;
		default:
			color = GameColor.purple;
			break;
		}
		
		gameObject.renderer.material = color.textureMaterial;
	}
	
	// Update is called once per frame
	void Update () {

        rigidbody.transform.position += new Vector3(-speed * Time.deltaTime, 0,0);
	}

	public float getSize()
	{
		return size;
	}
}
