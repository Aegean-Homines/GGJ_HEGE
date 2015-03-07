using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ControlManager : MonoBehaviour {

    public GameObject leftButton;
    public GameObject rightButton;

    private Player2D player;
    private RuntimePlatform platform;

    void Awake()
    {
        player = GameObject.Find("Playah").GetComponent<Player2D>();
        platform = Application.platform;
    }

    public void checkJumpButton()
    {
        player.checkJump();
    }

    public float getHorizontalMovement()
    {
        if (platform == RuntimePlatform.Android ||
            platform == RuntimePlatform.IPhonePlayer || true)
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);

            if (EventSystem.current.currentSelectedGameObject == leftButton)
            {
                return -1;
            }
            else if (EventSystem.current.currentSelectedGameObject == rightButton)
            {
                return 1;
            }
            else
                return 0f;
        }
        else
        {
            //Debug.Log(EventSystem.current);
            //Debug.Log(Input.GetAxis("Horizontal"));
            return Input.GetAxis("Horizontal");
        }
    }
}
