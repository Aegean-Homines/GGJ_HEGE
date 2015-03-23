using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ColorButton : MonoBehaviour
    {
        private Player2D _player;

        public int ColorIndex;

        void Awake()
        {
            _player = GameObject.Find("Playah").GetComponent<Player2D>();
        }

        public void ColorButtonEnter()
        {
            _player.CheckColorChange(ColorIndex);
        }
    }
}
