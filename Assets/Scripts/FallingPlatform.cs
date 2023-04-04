using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallSpeed;
    public float fallTimer;

    public Material on, off;
    Renderer r;

    public GameObject player;

    public bool isOn;
    public bool isOff;

    // Start is called before the first frame update
    void Start()
    {
        fallSpeed = 1.5f;

        r = GetComponent<Renderer>();

       isOff = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (isOff == true)
       {
            r.material = off;
         
       }
       else if (isOn == true)
       {


            fallTimer += Time.deltaTime;
            if (fallTimer >= 0.5)
            {
                r.material = on;
                //Platform moves down
                transform.Translate(new Vector3(0, -1 * Time.deltaTime, 0));


            }

           



       }



        if (fallTimer >= 1.5f)
        {

            Destroy(gameObject);
        }

    }

    

    

    private void OnCollisionStay2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            isOn = true;
            isOff = false;
            r.material = on;


           




        }

    }

   

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           // r.material = off;
            fallTimer += Time.deltaTime;
            if (fallTimer <= 0.5)
            {
                fallTimer = 0;
            }
           

            
        }
    }

    

}
