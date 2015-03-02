using UnityEngine;
using System.Collections;

public class StarCreator : MonoBehaviour {

	public GameObject star;

	public void createNewStar(Material colorMaterial){
		float rand_x, rand_y;
		for(int i = 0; i < Mathf.CeilToInt(Random.value*5) ;i++)
        {
            rand_x = Random.Range(-12.5f, 12.5f);
            rand_y = Random.Range(-15f, 15f);
			while(rand_x < -9 && rand_y > 6)
			{
				rand_x = Random.value*25-12.5f;
				rand_y = Random.value*20-10;
			}
			
			GameObject g =  Instantiate(star, new Vector3(rand_x, rand_y, 5), Quaternion.identity) as GameObject;
			g.renderer.material = colorMaterial;
			g.transform.parent = transform;
		}
	}


}
