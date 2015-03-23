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

            
            Vector2 buttonPosition = calculateButtonPosition(180f - i * (90f / (colors.Count - 1)));
            buttonPosition.x = - buttonPosition.x;
            buttonPosition.y = buttonPosition.y*Camera.main.aspect;
            buttonPosition = (buttonPosition)*.15f + new Vector2(1f, 0f);
            buttonPosition.x = 2 - buttonPosition.x;
            buttonPosition += new Vector2(-0.05f, 0.05f*Camera.main.aspect);
            Debug.Log(buttonPosition);
            newButton.anchorMax = newButton.anchorMin = buttonPosition;
            newButton.anchoredPosition = new Vector2(25, -25);
            
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
