using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float speed;
    public float health;
    public float damage;

    public Transform shootingRightSpawnPoint;
    public GameObject myWater1ObjectToSpawn;

    public Transform shootingLeftSpawnPoint;
    public GameObject myWater2ObjectToSpawn;

    public float waterShotTimer;
    

    public Animator myAnimator;
    public GameObject mySprite;

    public float waterTank;

    

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        health = 10.0f;

        damage = 1.0f;

        waterTank = 15.0f;

        waterShotTimer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        speed = 3.0f;


        waterShotTimer += Time.deltaTime;
        

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
                if (horizontalInput > 0)
                {
                    

                    if (waterShotTimer >= 1.0f)
                    {
                        //Player attacks
                        Debug.Log("You shot water");
                        GameObject WaterBall = Instantiate(myWater1ObjectToSpawn, shootingRightSpawnPoint.position, Quaternion.identity) as GameObject;
                        Rigidbody r = WaterBall.GetComponent<Rigidbody>();


                        //  Debug.Break();
                        r.AddRelativeForce(Vector3.right * 175);

                        //Lowers amount of water
                        waterTank = waterTank - 1;

                        waterShotTimer = 0;
                    }
                   
                }

                if (horizontalInput < 0)
                {
                   

                    if (waterShotTimer >= 1.0f)
                    {
                        //Player attacks
                        Debug.Log("You shot water");
                        GameObject WaterBall = Instantiate(myWater2ObjectToSpawn, shootingLeftSpawnPoint.position, Quaternion.identity) as GameObject;
                        Rigidbody r = WaterBall.GetComponent<Rigidbody>();


                        //  Debug.Break();
                        r.AddRelativeForce(Vector3.left * 175);

                        //Lowers amount of water
                        waterTank = waterTank - 1;

                        waterShotTimer = 0;
                    }

                }


            }
            else
            {
                //water tank is empty
                Debug.Log("No more water!");

            }

            if (health <= 0)
            {
                //Game ends
                Debug.Log("Game Over!");
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            myAnimator.SetBool("Attacked", true);

            // Player takes damage
            health = health - damage;
            Debug.Log("Ouch!");
        }
        else
        {
            myAnimator.SetBool("Attacked", false);
        }
    }
}
