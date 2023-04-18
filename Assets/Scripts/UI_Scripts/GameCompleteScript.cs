using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCompleteScript : MonoBehaviour
{
    public Image gameCompleteScreen;
    public Text gameCompleteMessage;
    public TMP_Text scoreText;
    public Button restart;


    public void Start()
    {
        restart.gameObject.SetActive(false);
    }

    public void SetEndScreen(bool isGameComplete)
    {

        if (isGameComplete)
        {
            gameCompleteScreen.enabled = true;
            gameCompleteMessage.enabled = true;
            scoreText.enabled = true;
            restart.gameObject.SetActive(true);
            restart.enabled = true;
        }
        else
        {
            gameCompleteScreen.enabled = false;
            gameCompleteMessage.enabled = false;
            scoreText.enabled = false;
            restart.gameObject.SetActive(false);
            restart.enabled = false;
        }

    }
}
