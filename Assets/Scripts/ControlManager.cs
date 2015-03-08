using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ControlManager : MonoBehaviour {

    public GameObject leftButton;
    public GameObject rightButton;

    private bool leftActive = false;
    private bool rightActive = false;

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

    public void leftButtonDown()
    {
        Debug.Log("left down");
        leftActive = true;
    }
    public void leftButtonUp()
    {
        Debug.Log("left up");
        leftActive = false;
    }
    public void rightButtonDown()
    {
        Debug.Log("right down");
        rightActive = true;
    }
    public void rightButtonUp()
    {
        Debug.Log("right up");
        rightActive = false;
    }

    public float getHorizontalMovement()
    {
        if (platform == RuntimePlatform.Android ||
            platform == RuntimePlatform.IPhonePlayer || true)
        {
            if (leftActive)
            {
                return -1f;
            }
            else if (rightActive)
            {
                return 1f;
            }
            else
                return 0f;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
}
