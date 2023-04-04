using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMegaScript : MonoBehaviour
{
    public float ascendTimer;
    private EnemyScript enemyScript;
   

    // Start is called before the first frame update
    void Start()
    {
      
        enemyScript = FindObjectOfType<EnemyScript>();

    }

    // Update is called once per frame
    void Update()
    {
       

        if (enemyScript.health <= 0)
        {
            ascendTimer += Time.deltaTime;

            if (ascendTimer <= 1)
            {
                transform.Translate(new Vector3(0, 0.5f * Time.deltaTime, 0));
                ascendTimer = 0;
            }
        }
       
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            // Bounce decreases
           
        }
    }
}
