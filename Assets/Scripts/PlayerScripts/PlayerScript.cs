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

    public bool gameOverNow;
    public GameOverScript gameOverScript;

    PlayerScript myPlayer_script;

    public Animator myAnimator;
    public GameObject mySprite;

    
    private int maxwater;
    public int currentwater;
    public WaterTankBar waterTankBar;

    //public WaterTankBar emptyTank;
    public bool outOfWater;

    private PlayerJump playerJump;

    public KeyCode absorbKey = KeyCode.X;

    public bool facingRight;
    public bool facingLeft;

    private MovingPlatform movingPlatform;
    private FallingPlatform fallingPlatform;

    public int coinsCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;

        maxhealth = 14;

        healthBar.SetMaxHealth(maxhealth);

        currenthealth = maxhealth;

        damage = 1.0f;

       
        maxwater = 12;

        waterTankBar.SetMaxWater(maxwater);

        waterTankBar.SetEmptyTank(outOfWater);
        outOfWater = false;

        waterShotTimer = 0.75f;
        waterBallTimer = 0.0f;

        facingRight = false;
        facingLeft = false;

        currentwater = maxwater;

        playerObjectPool = FindObjectOfType<PlayerObjectPool>();
        playerObjectPoolLeft = FindObjectOfType<PlayerObjectPoolLeft>();

        movingPlatform = FindObjectOfType<MovingPlatform>();
        fallingPlatform = FindObjectOfType<FallingPlatform>();

        playerJump = FindObjectOfType<PlayerJump>();

        gameOverScript.SetEndScreen(gameOverNow);
        gameOverNow = false;

       
    }


    // Update is called once per frame
    void Update()
    {
        speed = 3.0f;


        waterShotTimer += Time.deltaTime;


        
        if (currentwater >= 1)
        {
            waterTankBar.SetEmptyTank(outOfWater);
            outOfWater = false;
        }
        else if(currentwater <= 0)
        {
            waterTankBar.SetEmptyTank(outOfWater);
            outOfWater = true;
        }
        
       if (currenthealth > 0)
       {
            gameOverScript.SetEndScreen(gameOverNow);
            gameOverNow = false;
       }
       else if (currenthealth <= 0)
       {
            gameOverScript.SetEndScreen(gameOverNow);
            gameOverNow = true;
       }

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
            //not moving
            myAnimator.SetBool("Running", false);
            myAnimator.SetBool("Shooting", false);
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
                       
                        LoseWater(1);

                        waterShotTimer = 0;

                        waterTankBar.SetWater(currentwater);

                        GameObject waterBall = playerObjectPool.GetWaterBall();
                        waterBall.transform.position = transform.position + transform.right * 0.75f;
                        waterBall.transform.rotation = transform.rotation;
                        waterBall.SetActive(true);
                        outOfWater = false;

                        if (playerJump.isOnGround == false)
                        {
                            myAnimator.SetBool("Shooting", true);
                        }
                       

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

                        if (playerJump.isOnGround == false)
                        {
                            myAnimator.SetBool("Shooting", true);
                        }
                    }

                }
       


            }
            else
            {
                //water tank is empty
                outOfWater = true;
                waterTankBar.SetEmptyTank(outOfWater);
                Debug.Log("No more water!");
                myAnimator.SetBool("Shooting", true);
            }

       

           
        }
        
    }

    public void CollectedCoin(int numberOfCoinsCollectedInThisAction)
    {
        coinsCollected += numberOfCoinsCollectedInThisAction;
        

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

            

            if (currenthealth <= 0)
            {
                //Game ends
                Debug.Log("Game Over!");
                myAnimator.SetBool("Attacked", true);
              //  Time.timeScale = 0;

               
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

            if (currenthealth <= 0)
            {
                //Game ends
                Debug.Log("Game Over!");
                myAnimator.SetBool("Attacked", true);
                Time.timeScale = 0;

                
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
                
                if (Input.GetKeyDown(absorbKey))
                {
                    currentwater = 12;
                    Debug.Log("Water tank filled up");
                    Destroy(other.gameObject);

                waterTankBar.SetWater(currentwater);
                }


            }

        if (other.gameObject.tag == "EndlessPit")
        {
            TakeDamage(14);
            healthBar.SetHealth(currenthealth);
           // Destroy(gameObject);
            Debug.Log("GameOver");
            myAnimator.SetBool("Attacked", true);
            Time.timeScale = 0;

           
        }
       
    }

   

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            //Player moves along the platform
            if (movingPlatform.moveTimer <= 3.0f)
            {
                //Platform moves right
                transform.Translate(new Vector3(1 * Time.deltaTime, 0, 0));




            }
            else if (movingPlatform.moveTimer <= 6.0f)
            {
                //Platform moves left
                transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0));


            }

        }

        if (collision.gameObject.tag == "FallingPlatform")
        {
            //Player moves along the platform
            
            
                //Platform moves down
                transform.Translate(new Vector3(0, -1 * Time.deltaTime * fallingPlatform.fallSpeed, 0));




            
           

        }
    }


}
