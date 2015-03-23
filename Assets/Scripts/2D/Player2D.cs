using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Player2D : MonoBehaviour {
	
	public float jumpSpeed;
	public float Speed;
	public bool OnAir;
	public GameColor2D Color;
	
	public StarCreator stars;
    public ParticleCreator particles;

	private List<GameObject> _collidingPlatforms;

    private Rigidbody2D _rBody;
    private AudioSource _audioSource;
    private ControlManager _controlManager;

    private List<GameColor2D> _colors;

    private Transform _groundCheck;

	public float maxSpeed = 5f;
    void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _colors = GameColor2D.getAvailableColors(GameData.difficulty);
        _controlManager = GameObject.Find("controlManager").GetComponent<ControlManager>();
    }
	void Start () {
		OnAir = true;
        Color = null;
        _collidingPlatforms = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

        CheckColorChange();
		
		if(Color != null)
			gameObject.GetComponent<Renderer>().material = Color.textureMaterial;

        if (Input.GetButtonDown("Vertical"))
        {
            CheckJump();
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

    public void CheckJump()
    {
        if (!OnAir)
        {
            _rBody.AddForce(new Vector2(0f, jumpSpeed));
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }

    public void CheckColorChange(int colorIndex = -1)
    {
        if (OnAir)
        {
            if (colorIndex != -1)
            {
                Color = _colors[colorIndex];
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Color = GameColor2D.blue;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Color = GameColor2D.purple;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Color = GameColor2D.green;
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    Color = GameColor2D.yellow;
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    Color = GameColor2D.red;
                }
            }

            GameObject.Find("gameDataContainer2D").GetComponent<PlatformPool2D>().disablePlatforms(Color);
        }
    }

	void FixedUpdate(){
		// Cache the horizontal input.
        float h = _controlManager.getHorizontalMovement();

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * _rBody.velocity.x < maxSpeed)
        {
            Debug.Log(_rBody);
			// ... add a force to the player.
            _rBody.AddForce(Vector2.right * h * Speed);

		}
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

	}
	
	void OnCollisionEnter2D(Collision2D other)
    {
        if (!_collidingPlatforms.Contains(other.gameObject))
        {
            _collidingPlatforms.Add(other.gameObject);
        }
        OnAir = false;
        if (other.gameObject.name != "memePlatform2D") 
		{
			stars.createNewStar(Color.textureMaterial);
            particles.createParticleSystem(Color.textureMaterial, transform.position, other.gameObject.transform);
		}
	}

	void OnCollisionExit2D(Collision2D other)
    {
        if (_collidingPlatforms.Remove(other.gameObject) && 
            _collidingPlatforms.Count == 0)
        {
            OnAir = true;
        }
	}
}
