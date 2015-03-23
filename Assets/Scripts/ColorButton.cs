using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ColorButton : MonoBehaviour
    {
        private Image _buttonTexture;

        void Awake()
        {
            _buttonTexture = GetComponent<Image>();;
        }

        void Update ()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log(_buttonTexture.color);
            }
        }
    }
}
