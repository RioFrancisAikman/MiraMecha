using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Image gameOverScreen;
    public Text gameOverMessage;
    public Button restart;


    public void Start()
    {
        restart.gameObject.SetActive(false);
    }

    public void SetEndScreen(bool isGameOver)
    {

        if (isGameOver)
        {
            gameOverScreen.enabled = true;
            gameOverMessage.enabled = true;
            restart.gameObject.SetActive(true);
            restart.enabled = true;
        }
        else
        {
            gameOverScreen.enabled = false;
            gameOverMessage.enabled = false;
            restart.gameObject.SetActive(false);
            restart.enabled = false;
        }

    }
}
