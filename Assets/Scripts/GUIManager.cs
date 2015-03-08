using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

    private Text scoreGUI;
    private Text highScoreGUI;
    private Canvas canvas;

    public RectTransform ColorButton;

    void Awake()
    {
        scoreGUI = GameObject.Find("Score").GetComponent<Text>();
        highScoreGUI = GameObject.Find("High Score").GetComponent<Text>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    void Start()
    {
        createColorButtons();
    }

    void Update()
    {
        updateGuiElements();
    }

    private void updateGuiElements()
    {
        scoreGUI.text = "Score: " + GameData.score;
        highScoreGUI.text = "High Score: " + GameData.highScore;
    }

    private void createColorButtons()
    {
        List<GameColor2D> colors = GameColor2D.getAvailableColors(GameData.difficulty);

        for (int i = 0; i < colors.Count; i++)
        {
            GameColor2D gameColor2D = colors[i];
            RectTransform newButton = Instantiate(ColorButton, new Vector3(0, 0, 0), Quaternion.identity) as RectTransform;
            Image buttonTexture = newButton.GetComponent<Image>();
            buttonTexture.color = gameColor2D.textureMaterial.color;
            newButton.SetParent(canvas.transform);

            Vector3 buttonPosition = calculateButtonPosition(180f - i * (90f / (colors.Count - 1))) + new Vector3();
            //newButton.sizeDelta = new Vector2(0.25f, 0.25f);
            Vector3 bottomRight = new Vector3(canvas.gameObject.GetComponent<RectTransform>().rect.width, 0, 0);
            buttonPosition += bottomRight;
            newButton.position = buttonPosition;
        }
    }

    private Vector3 calculateButtonPosition(float calibrationAmount)
    {
        Vector3 leftVector = new Vector3(1f, 0f, 0f);
        float _x = leftVector.x;
        float _y = leftVector.y;

        float _angle = calibrationAmount * Mathf.Deg2Rad;
        float _cos = Mathf.Cos(_angle);
        float _sin = Mathf.Sin(_angle);

        float _x2 = _x * _cos - _y * _sin;
        float _y2 = _x * _sin + _y * _cos;

        return new Vector2(_x2, _y2) * 150;
    }
}
