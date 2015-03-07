using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Player2D : MonoBehaviour {
	
	public float jumpSpeed;
	public float speed;
	public bool onAir;
	private Transform groundCheck;
	public GameColor2D color;
	public AudioClip gameOverClip;
	
	public StarCreator stars;
    public ParticleCreator particles;

	private List<GameObject> collidingPlatforms;

    private Rigidbody2D rBody;
    private AudioSource audioSource;
    private ControlManager controlManager;

	public float maxSpeed = 5f;
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        controlManager = GameObject.Find("controlManager").GetComponent<ControlManager>();
    }
	void Start () {
		onAir = true;
        color = null;
        collidingPlatforms = new List<GameObject>();
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
			gameObject.GetComponent<Renderer>().material = this.color.textureMaterial;

        if (Input.GetButtonDown("Vertical"))
        {
            checkJump();
        }

		if(gameObject.transform.position.y <= -15)
		{
			Application.LoadLevel("GameOverScreen");

			if(GameData.score > GameData.highScore)
			{
				GameData.highScore = GameData.score;
				PlayerPrefs.SetInt("High Score", GameData.highScore);
			}
		}
	}

    public void checkJump()
    {
        if (!onAir)
        {
            rBody.AddForce(new Vector2(0f, jumpSpeed));
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

	void FixedUpdate(){
		// Cache the horizontal input.
        float h = controlManager.getHorizontalMovement();

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rBody.velocity.x < maxSpeed)
		{
			// ... add a force to the player.
            rBody.AddForce(Vector2.right * h * speed);

		}
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

	}
	
	void OnCollisionEnter2D(Collision2D other)
    {
        if (!this.collidingPlatforms.Contains(other.gameObject))
        {
            this.collidingPlatforms.Add(other.gameObject);
        }
        onAir = false;
        if (other.gameObject.name != "memePlatform2D") 
		{
			stars.createNewStar(this.color.textureMaterial);
            particles.createParticleSystem(this.color.textureMaterial, transform.position, other.gameObject.transform);
		}
	}

	void OnCollisionExit2D(Collision2D other)
    {
        if (this.collidingPlatforms.Remove(other.gameObject) && 
            this.collidingPlatforms.Count == 0)
        {
            onAir = true;
        }
	}
}
