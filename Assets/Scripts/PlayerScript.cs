using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float speed;

    public Transform shootingSpawnPoint;
    public GameObject myWaterObjectToSpawn;

    public Animator myAnimator;
    public GameObject mySprite;

    public float waterTank;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        waterTank = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        speed = 3.0f;

        //Player Movement Code
        //read the input of the horizontal and vertical, store them in a variable
        float horizontalInput = Input.GetAxis("Horizontal");
        

        //Debug.Log("The vertical is " + verticalInput + " and the horizontal is " + horizontalInput);
        Vector3 inputFromPlayer = new Vector3(horizontalInput, 0, 0);

        //move the player based on the values
        transform.Translate(inputFromPlayer * speed * Time.deltaTime);



        if (horizontalInput > 0)
        {
            //moving to the right
            myAnimator.SetBool("Running", true);
            mySprite.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (horizontalInput < 0)
        {
            //moving to the left
            myAnimator.SetBool("Running", true);
            mySprite.transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        else
        {
            //not moving to the right
            myAnimator.SetBool("Running", false);
        }


        if (Input.GetButtonDown("WaterShot"))
        {
            if (waterTank >= 1.0f)
            {

                Debug.Log("You shot water");
                GameObject WaterBall = Instantiate(myWaterObjectToSpawn, shootingSpawnPoint.position, Quaternion.identity) as GameObject;
                Rigidbody r = WaterBall.GetComponent<Rigidbody>();

                
                //  Debug.Break();
                r.AddRelativeForce(Vector3.right * 150);
                
            }
            else
            {
                //water tank is empty
                Debug.Log("No more water!");

            }
        }
    }
}
