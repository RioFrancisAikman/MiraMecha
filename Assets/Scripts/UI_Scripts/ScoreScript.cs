using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public TMP_Text scoreText;
    public int currentCoins = 0;
   
 

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       
             scoreText.text = currentCoins.ToString();

        
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;


        scoreText.text = "Score: " + currentCoins.ToString();
    }
}

