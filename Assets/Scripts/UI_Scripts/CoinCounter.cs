using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coinText;
    public int currentCoins = 0;
    public bool isCoinCounter;
    public bool isCoinScore;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isCoinCounter == true)
        {
            coinText.text = currentCoins.ToString();
        }

        if (isCoinScore == true)
        {
            coinText.text = "Score: " + currentCoins.ToString();
        }
    }

    public void IncreaseCoins(int v)
    {

        if (isCoinCounter == true)
        {
            currentCoins += v;
            coinText.text = currentCoins.ToString();
        }

        if (isCoinScore == true)
        {
            currentCoins += v;
            coinText.text = "Score: " + currentCoins.ToString();
        }
    }
}
