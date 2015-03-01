using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player2D : MonoBehaviour {
	
	public float jumpSpeed;
	public float speed;
	public bool onAir;
	private Transform groundCheck;
	private bool grounded = false;
	private string name;
	public GameColor2D color;
	public AudioClip gameOverClip;
	
	public StarCreator stars;

	private GameObject collidingPlatform;

	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	// Use this for initialization
	void Start () {
		onAir = true;
		color = null;
		collidingPlatform = null;
	}
	
	// Update is called once per frame
	void Update () {

		if(onAir){
			if(Input.GetKeyDown(KeyCode.Alpha1))
			{
				this.color = GameColor2D.blue;
			}
			if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				this.color = GameColor2D.purple;
			}
			if(Input.GetKeyDown(KeyCode.Alpha3))
			{
				this.color = GameColor2D.green;
			}
			if(Input.GetKeyDown(KeyCode.Alpha4))
			{
				this.color = GameColor2D.yellow;
			}
			if(Input.GetKeyDown(KeyCode.Alpha5))
			{	
				this.color = GameColor2D.red;
			}
			
			GameObject.Find("gameDataContainer2D").GetComponent<PlatformPool2D>().disablePlatforms(this.color);
		}
		
		if(color != null)
			gameObject.renderer.material = this.color.textureMaterial;
		if(!onAir && Input.GetButtonDown("Vertical"))
		{			
			//Debug.Log ("UpArrow pressed");
			//Debug.Log("zipladik");
			rigidbody2D.AddForce(new Vector2(0f, jumpSpeed));
			this.audio.PlayOneShot (audio.clip);

		}

		if(gameObject.transform.position.y <= -10)
		{

			Application.LoadLevel("GameOverScreen");

			if(GameData.score > GameData.highScore)
			{
				GameData.highScore = GameData.score;
				PlayerPrefs.SetInt("High Score", GameData.highScore);
			}
		}
	}
	
	void FixedUpdate(){
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed)
		{
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * speed);

		}
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (this.collidingPlatform == null) {
			this.collidingPlatform = other.gameObject;
		}
		onAir = false;
		if (other.gameObject.name != "memePlatform2D") 
		{
			stars.createNewStar(this.color.textureMaterial);
		}
		//Debug.Log("OnCollisionEnter");
	}

	void OnCollisionExit2D(Collision2D other){
		if (this.collidingPlatform != null) {
			onAir = true;
		}
		//Debug.Log("OnCollisionExit");
	}


}
