using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int value;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
      
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Coin collected");

            Destroy(gameObject, 0.1f);
            CoinCounter.instance.IncreaseCoins(value);

            //added coin to player
            if (value == 1)
            {
                collider.gameObject.GetComponent<PlayerScript>().CollectedCoin(1);
            }
            else if (value == 5)
            {
                collider.gameObject.GetComponent<PlayerScript>().CollectedCoin(5);
            }


        }
    }

}
