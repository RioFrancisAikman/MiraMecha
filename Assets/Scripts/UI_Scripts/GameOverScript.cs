using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Image gameOverScreen;
    public Text gameOverMessage;
    public Button restart;
    

    public void SetEndScreen(bool isGameOver)
    {

        if (isGameOver)
        {
            gameOverScreen.enabled = true;
            gameOverMessage.enabled = true;
            restart.enabled = true;
        }
        else
        {
            gameOverScreen.enabled = false;
            gameOverMessage.enabled = false;
            restart.enabled = false;
        }

    }
}
