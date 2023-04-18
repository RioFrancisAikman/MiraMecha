using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(playerScript.coinsCollected >= 30)
            {
                Debug.Log("Level Complete");
                transform.Translate(new Vector3(0, 55 * Time.deltaTime, 0));
            }
            else
            {
                Debug.Log("Insufficient Amount Obtained");
            }
        }
    }
}
