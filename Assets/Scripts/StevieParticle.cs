using UnityEngine;
using System.Collections;

public class StevieParticle : MonoBehaviour {

    private float creationTime;
    private ParticleSystem particle;

    public float particleEmitDuration;

    void Awake()
    {
        particle = gameObject.GetComponent<ParticleSystem>();
    }

	void Start () {
        creationTime = Time.time;
	}
	
	void Update () {
	    if (Time.time - creationTime >= particleEmitDuration)
        {
            particle.enableEmission = false;
            Destroy(gameObject, 5);
        }
	}
}
