using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformCreator2D : MonoBehaviour {
	
	public GameObject platform;
	private List<GameObject> objectArray = new List<GameObject>();
	private int randomNumber, oldRandom;
	private float lastTime;
	public float threshold = 2.0f;
	public int counter;

    private Player2D player;
    private GameData gameData;
    private PlatformPool2D pool;
	// Use this for initialization
	void Start () {
		lastTime = 0;
	}

    void Awake()
    {
        this.player = GameObject.Find("Playah").GetComponent<Player2D>();
        this.pool = gameObject.GetComponent<PlatformPool2D>();
        this.gameData = gameObject.GetComponent<GameData>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time - lastTime > threshold)
		{
			oldRandom = Mathf.FloorToInt((Random.value*8 - 4));
			randomNumber = Mathf.FloorToInt((Random.value*4 - 2));
			
			if(oldRandom == randomNumber)
			{
                pool.getPlatform(randomNumber);
			}
			else
			{
				pool.getPlatform(randomNumber);
                pool.getPlatform(oldRandom);
			}
			lastTime = Time.time;
			
			counter++;
			if (counter == 8)
			{
				counter = 0;
				gameData.gameSpeed += 1;
				threshold -= (threshold / 10);
                player.speed += 0.8f;
			}
		}
		
	}
}
