using UnityEngine;
using System.Collections;

public class StevieParticle : MonoBehaviour {

    private float creationTime;
    private ParticleSystem particleSystem;

    public float particleEmitDuration;

    void Awake()
    {
        particleSystem = gameObject.GetComponent<ParticleSystem>();
    }

	void Start () {
        creationTime = Time.time;
	}
	
	void Update () {
	    if (Time.time - creationTime >= particleEmitDuration)
        {
            particleSystem.enableEmission = false;
            Destroy(gameObject, 5);
        }
	}
}
