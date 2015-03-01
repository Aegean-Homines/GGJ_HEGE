using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

    private GameData gameData;
    private float parallax;

    void Awake()
    {
        GameObject dataContainer = GameObject.Find("gameDataContainer2D");
        this.gameData = dataContainer.GetComponent<GameData>();

        parallax = Random.Range(1.0f, 3.0f) / 5.0f;

        transform.localScale = new Vector3(parallax * 5, parallax * 5, 1);
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(-(gameData.gameSpeed) * parallax * Time.deltaTime, 0, 0);

        if (transform.position.x <= -20.0f)
        {
            Vector3 newPos = transform.position;
            newPos.x = 20.0f;
            transform.position = newPos;
        }
    }
}
