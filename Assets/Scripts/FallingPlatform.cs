using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallSpeed;
 

    // Start is called before the first frame update
    void Start()
    {
        fallSpeed = 4.5f;

        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

                
                //Platform moves down
                transform.Translate(new Vector3(0, -1 * Time.deltaTime * fallSpeed, 0));

          
            
            
        }
    }
}
