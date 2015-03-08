using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

    private Text scoreGUI;
    private Text highScoreGUI;

    void Awake()
    {
        scoreGUI = GameObject.Find("Score").GetComponent<Text>();
        highScoreGUI = GameObject.Find("High Score").GetComponent<Text>();

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
    }
}
