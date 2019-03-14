using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Sprite[] Lives;
    public Image liveDisplay;

    public void updateLives(int currentLives)
    {
        Debug.Log(currentLives);
        liveDisplay.sprite = Lives[currentLives];
    }

    public void updateScore()
    {

    }
}
