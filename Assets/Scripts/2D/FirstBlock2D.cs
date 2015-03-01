using UnityEngine;
using System.Collections;

public class FirstBlock2D : MonoBehaviour
{
    private GameData gameData;

	void Start(){
		GameObject dataContainer = GameObject.Find("gameDataContainer2D");
        gameData = dataContainer.GetComponent<GameData>();
	}
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(-(gameData.gameSpeed) * Time.deltaTime, 0,0);
	}
}
