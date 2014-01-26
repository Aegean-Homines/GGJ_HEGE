using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public float jumpSpeed;
    public float speed;
    public bool onAir;
	private Transform groundCheck;
	private bool grounded = false;
	private string name;
	public GameColor color;
	
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	// Use this for initialization
	void Start () {
		onAir = true;
		color = null;
	}
	
	// Update is called once per frame
	void Update () {

		if(onAir){
			if(Input.GetKeyDown(KeyCode.Alpha1))
			{
				this.color = GameColor.blue;
			}
			if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				this.color = GameColor.green;
			}
			if(Input.GetKeyDown(KeyCode.Alpha3))
			{
				this.color = GameColor.purple;
			}
			if(Input.GetKeyDown(KeyCode.Alpha4))
			{
				this.color = GameColor.red;
			}
			if(Input.GetKeyDown(KeyCode.Alpha5))
			{	
				this.color = GameColor.yellow;
			}

			GameObject.Find("gameDataContainer").GetComponent<PlatformPool>().disablePlatforms(this.color);
		}

		if(color != null)
			gameObject.renderer.material = this.color.textureMaterial;
		if(!onAir && Input.GetButtonDown("Vertical"))
		{			
			//Debug.Log ("UpArrow pressed");
			rigidbody.AddForce(new Vector2(0f, jumpSpeed));
		}

	}

	void FixedUpdate(){
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody.AddForce(Vector2.right * h * speed);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody.velocity = new Vector2(Mathf.Sign(rigidbody.velocity.x) * maxSpeed, rigidbody.velocity.y);
	}

	void OnCollisionEnter(){
		onAir = false;
		//Debug.Log("OnCollisionEnter");
	}

	void OnCollisionExit(){
		onAir = true;
		//Debug.Log("OnCollisionExit");
	}
}
