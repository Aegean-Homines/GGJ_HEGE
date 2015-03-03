using UnityEngine;
using System.Collections;

public class ParticleCreator : MonoBehaviour
{
    public GameObject particle;

    public void createParticleSystem(Material colorMaterial, Vector3 relativePos, Transform parent)
    {
        Vector3 particlePos = particle.transform.position;
        GameObject newParticle = Instantiate(particle, particlePos + relativePos, particle.transform.rotation) as GameObject;
        newParticle.transform.parent = parent;
        newParticle.GetComponent<ParticleSystem>().startColor = colorMaterial.color;
    }


}
