using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float speed;
    public int maxhealth;
    public int currenthealth;
    public HealthBar healthBar;
    public float damage;

    public Transform shootingRightSpawnPoint;
    public GameObject myWater1ObjectToSpawn;

    public Transform shootingLeftSpawnPoint;
    public GameObject myWater2ObjectToSpawn;

    public float waterShotTimer;
    public float waterBallTimer;

    public GameObject waterBallPrefab;
    private PlayerObjectPool playerObjectPool;
    private PlayerObjectPoolLeft playerObjectPoolLeft;

    PlayerScript myPlayer_script;

    public Animator myAnimator;
    public GameObject mySprite;

    
    private int maxwater;
    public int currentwater;
    public WaterTankBar waterTankBar;

    public KeyCode absorbKey = KeyCode.X;

    public bool facingRight;
    public bool facingLeft;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;

        maxhealth = 20;

        healthBar.SetMaxHealth(maxhealth);

        currenthealth = maxhealth;

        damage = 1.0f;

       
        maxwater = 12;

        waterTankBar.SetMaxWater(maxwater);

        waterShotTimer = 0.75f;
        waterBallTimer = 0.0f;

        facingRight = false;
        facingLeft = false;

        currentwater = maxwater;

        playerObjectPool = FindObjectOfType<PlayerObjectPool>();
        playerObjectPoolLeft = FindObjectOfType<PlayerObjectPoolLeft>();
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

            facingRight = true;
            facingLeft = false;
        }
        else if (horizontalInput < 0)
        {
            //moving to the left
            myAnimator.SetBool("Running", true);
            mySprite.transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);

            facingLeft = true;
            facingRight = false;
           
        }
        else
        {
            //not moving to the right
            myAnimator.SetBool("Running", false);
        }





        waterBallTimer += Time.deltaTime;

        /* if (waterBallTimer >= 2)
         {

             waterBallTimer = 0;
         }
        */
        
        if (Input.GetButtonDown("WaterShot"))
        {
            if (currentwater >= 1.0)
            {
                
                if (facingRight == true)
                {
                   

                    if (waterShotTimer >= 0.75f)
                    {
                        //Player attacks
                        /*
                        Debug.Log("You shot water");
                        GameObject WaterBall = Instantiate(myWater1ObjectToSpawn, shootingRightSpawnPoint.position, Quaternion.identity) as GameObject;
                        Rigidbody2D r = WaterBall.GetComponent<Rigidbody2D>();


                        //  Debug.Break();
                        r.AddRelativeForce(Vector2.right * 25);
                        */
                        //Lowers amount of water
                        LoseWater(1);

                        waterShotTimer = 0;

                        waterTankBar.SetWater(currentwater);

                        GameObject waterBall = playerObjectPool.GetWaterBall();
                        waterBall.transform.position = transform.position + transform.right * 0.75f;
                        waterBall.transform.rotation = transform.rotation;
                        waterBall.SetActive(true);

                    }
                   
                }
                else if (facingLeft == true)
                {
                   

                    if (waterShotTimer >= 0.75f)
                    {
                        //Player attacks
                        /*
                        Debug.Log("You shot water");
                        GameObject WaterBall = Instantiate(myWater2ObjectToSpawn, shootingLeftSpawnPoint.position, Quaternion.identity) as GameObject;
                        Rigidbody2D r = WaterBall.GetComponent<Rigidbody2D>();


                        //  Debug.Break();
                        r.AddRelativeForce(Vector2.left * 25);
                        */
                        //Lowers amount of water
                        LoseWater(1);

                        waterShotTimer = 0;



                        waterTankBar.SetWater(currentwater);

                        GameObject waterBall = playerObjectPoolLeft.GetWaterBall();
                        waterBall.transform.position = transform.position + transform.right * -0.75f;
                        waterBall.transform.rotation = transform.rotation;
                        waterBall.SetActive(true);

                    }

                }
       


            }
            else
            {
                //water tank is empty
                Debug.Log("No more water!");

            }

       

           
        }
        
    }

   


    void LoseWater(int loseWater)
    {
        currentwater -= loseWater;
    }

    void TakeDamage(int damage)
    {
        currenthealth -= damage;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            myAnimator.SetBool("Attacked", true);

            // Player takes damage
            TakeDamage(1);
            healthBar.SetHealth(currenthealth);

            Debug.Log("Ouch!");

            

            if (maxhealth <= 0)
            {
                //Game ends
                Debug.Log("Game Over!");
            }
        }
        else
        {
            myAnimator.SetBool("Attacked", false);
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            myAnimator.SetBool("Attacked", true);

            // Player takes damage
            TakeDamage(1);
            healthBar.SetHealth(currenthealth);

            Debug.Log("Ouch!");

            if (maxhealth <= 0)
            {
                //Game ends
                Debug.Log("Game Over!");
            }
        }
        else
        {
            myAnimator.SetBool("Attacked", false);
        }

       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
       
        
            if (other.gameObject.tag == "WaterTank")
            {
                Debug.Log("Collect Water?");
                if (Input.GetKeyDown(absorbKey))
                {
                    currentwater = 12;
                    Debug.Log("Water tank filled up");
                    Destroy(other.gameObject);

                waterTankBar.SetWater(currentwater);
                }


            }
       
    }

    
}
