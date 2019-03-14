using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Sprite[] Lives;
    public Image liveDisplay;

    public int score;
    public Text scoreText;

    public GameObject title;

    public void updateLives(int currentLives)
    {
        liveDisplay.sprite = Lives[currentLives];
    }

    public void updateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
    public void showTitle()
    {
        title.SetActive(true);
    }
    public void hideTitle()
    {
        title.SetActive(false);
        scoreText.text = "Score: ";
    }

}
