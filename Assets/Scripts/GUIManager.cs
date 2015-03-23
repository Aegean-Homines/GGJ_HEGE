using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GUIManager : MonoBehaviour {

        private Text _scoreGui;
        private Text _highScoreGui;
        private Canvas _canvas;

        public RectTransform ColorButton;

        void Awake()
        {
            _scoreGui = GameObject.Find("Score").GetComponent<Text>();
            _highScoreGui = GameObject.Find("High Score").GetComponent<Text>();
            _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        }

        void Start()
        {
            CreateColorButtons();
        }

        void Update()
        {
            UpdateGuiElements();
        }

        private void UpdateGuiElements()
        {
            _scoreGui.text = "Score: " + GameData.score;
            _highScoreGui.text = "High Score: " + GameData.highScore;
        }

        private void CreateColorButtons()
        {
            List<GameColor2D> colors = GameColor2D.getAvailableColors(GameData.difficulty);
            float aspectRatio = Camera.main.aspect;
            for (int i = 0; i < colors.Count; i++)
            {
                GameColor2D gameColor2D = colors[i];
                RectTransform newButton = Instantiate(ColorButton, new Vector3(0, 0, 0), Quaternion.identity) as RectTransform;
                if (newButton != null)
                {
                    ColorButton colorButton = newButton.GetComponent<ColorButton>();
                    colorButton.ColorIndex = i;
                    Image buttonTexture = newButton.GetComponent<Image>();
                    buttonTexture.color = gameColor2D.textureMaterial.color;
                    newButton.SetParent(_canvas.transform);

                    Vector2 buttonPosition = calculateButtonPosition(180f - i * (90f / (colors.Count - 1)));
                    buttonPosition.x = - buttonPosition.x;
                    buttonPosition.y = buttonPosition.y * aspectRatio;
                    buttonPosition = (buttonPosition)*.15f + new Vector2(1f, 0f);
                    buttonPosition.x = 2 - buttonPosition.x;
                    buttonPosition += new Vector2(-0.05f, 0.05f * aspectRatio);

//                    float yRatio = newButton.rect.height / Screen.height;
//                    float xRatio = newButton.rect.width / Screen.width;
                    float yRatio = .065f * aspectRatio;
                    float xRatio = .065f;
                    newButton.anchorMax = buttonPosition + new Vector2(xRatio, yRatio)/2;
                    newButton.anchorMin = buttonPosition - new Vector2(xRatio, yRatio)/2;
                    newButton.offsetMax = new Vector2();
                    newButton.offsetMin = new Vector2();
                    newButton.anchoredPosition = new Vector2();
                }
            }
        }

        private Vector2 calculateButtonPosition(float calibrationAmount)
        {
            Vector3 leftVector = new Vector3(1f, 0f, 0f);
            float x = leftVector.x;
            float y = leftVector.y;

            float angle = calibrationAmount * Mathf.Deg2Rad;
            float cos = Mathf.Cos(angle);
            float sin = Mathf.Sin(angle);

            float x2 = x * cos - y * sin;
            float y2 = x * sin + y * cos;

            return new Vector2(x2, y2);
        }
    }
}
