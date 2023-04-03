using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum EnemyStates { walking, chasing, retreat, positioning }
    public EnemyStates enemyActStates;

    public GameObject player;
    PlayerScript myPlayer_script;

    public float speed = 1;
    public float health;
    public float damage;

    public EnemyDetection volumeToMonitor;

    public float forwardTimer;
    public float upTimer;
    public float shootTimer;

    public Material on, off;
    Renderer r;

    public GameObject myEnemySprite;

    public Transform shooting1SpawnPoint;
    public GameObject myEnemy1ObjectToSpawn;
    public Transform shooting2SpawnPoint;
    public GameObject myEnemy2ObjectToSpawn;

    public bool facingRight;
    public bool facingLeft;
    
    private float distance;

    public Transform playerTransfer;
    public Transform gameObjectTransform;
    public float playerNearby = 1.25f;
    

    private EnemyObjectPool enemyObjectPool;
    private EnemyObjectPoolLeft enemyObjectPoolLeft;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();

        speed = 1.5f;
        health = 4.0f;
        damage = 1.0f;

        player = GameObject.FindGameObjectWithTag("Player");

       
        

        facingRight = false;
        facingLeft = false;

        myPlayer_script = player.GetComponent<PlayerScript>();

        enemyObjectPool = FindObjectOfType<EnemyObjectPool>();
        enemyObjectPoolLeft = FindObjectOfType<EnemyObjectPoolLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }


        float distanceAway = Vector2.Distance(gameObjectTransform.position, playerTransfer.position);



        upTimer += Time.deltaTime;


        shootTimer += Time.deltaTime;

        switch (enemyActStates)
        {
            case EnemyStates.walking:

                //Enemy is calm
                r.material = off;

                forwardTimer += Time.deltaTime;


                if (forwardTimer <= 5.0f)
                {
                    //Enemy moves right
                    transform.Translate(new Vector3(1 * Time.deltaTime, 0, 0));
                    myEnemySprite.transform.localScale = new Vector3(-1.75f, 1.75f, 1.75f);

                    
                    facingRight = true;
                    facingLeft = false;

                }
                else if (forwardTimer <= 10.0f)
                {
                    //Enemy moves left
                    transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0));
                    myEnemySprite.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

                    facingLeft = true;
                    facingRight = false;

                }
                else if (forwardTimer >= 10.0f)
                {
                    // resets timer
                    forwardTimer = 0;
                }

                //Player is within sight
                if (volumeToMonitor.playerInsideVolume == true)
                {

                    if (health >= 3)
                    {
                        
                        enemyActStates = EnemyStates.chasing;
                    }
                    else if (health <= 2)
                    {
                        enemyActStates = EnemyStates.retreat;
                    }


                    
                   

                }

                break;

            case EnemyStates.chasing:

                // Enemy becomes angry
                r.material = on;


                /*
                if (facingRight == true)
                {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                }

                if (facingLeft == true)
                {
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                }
                */

                /*
                if (upTimer <= 1.5f)
                {
                    transform.Translate(new Vector3(0, 1 * Time.deltaTime, 0));
                    
                }
                else if (upTimer <= 3.0f)
                {
                    transform.Translate(new Vector3(0, -1 * Time.deltaTime, 0));
                   
                }
                else if (upTimer >= 3.0f)
                {
                    upTimer = 0;
                }
                */

                if (facingRight == true)
                {
                    Vector2 attackDirection = player.transform.position - transform.position;
                    // transform.Translate(attackDirection.normalized * 1.5f * Time.deltaTime);

                    float angle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;

                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                }

                else if (facingLeft == true)
                {
                    Vector2 attackDirection = transform.position - player.transform.position;
                    // transform.Translate(attackDirection.normalized * 1.5f * Time.deltaTime);

                    float angle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;

                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                }
                if (distanceAway <= playerNearby)
                {
                    // Stops moving
                    speed = 0;
                }
                else
                {
                    speed = 1.5f;
                }

                // float angle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
                // transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                /*
                if (facingRight == true)
                {
                    distance = Vector2.Distance(transform.position, player.transform.position);
                    Vector2 direction = player.transform.position - transform.position;
                    direction.Normalize();
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                }

                if (facingLeft == true)
                {
                    distance = Vector2.Distance(transform.position, player.transform.position);
                    Vector2 direction = transform.position - player.transform.position;
                    direction.Normalize();
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                }
                */



                if (volumeToMonitor.playerInsideVolume == false)
                {
                    //Player is not within sight
                    enemyActStates = EnemyStates.walking;


                }

                if (health <= 2)
                {
                    enemyActStates = EnemyStates.retreat;
                }
                
               
               
                

                if (shootTimer >= 4.0f)
                {

                    if (facingRight == true)
                    {
                        /*GameObject EnemyShot = Instantiate(myEnemy1ObjectToSpawn, shooting1SpawnPoint.position, Quaternion.identity) as GameObject;
                        Rigidbody2D sr = EnemyShot.GetComponent<Rigidbody2D>();

                        //  Debug.Break();
                        sr.AddRelativeForce(Vector2.right * 50);
                        */
                        GameObject enemyBullet = enemyObjectPool.GetEnemyBullet();
                        enemyBullet.transform.position = transform.position + transform.right * 0.75f;
                        enemyBullet.transform.rotation = transform.rotation;
                        enemyBullet.SetActive(true);

                        shootTimer = 0;
                    }
                    else if (facingLeft == true)
                    {
                        /*GameObject EnemyShot = Instantiate(myEnemy2ObjectToSpawn, shooting2SpawnPoint.position, Quaternion.identity) as GameObject;
                        Rigidbody2D sr = EnemyShot.GetComponent<Rigidbody2D>();

                        //  Debug.Break();
                        sr.AddRelativeForce(Vector2.left * 50);
                        */
                        GameObject enemyBullet = enemyObjectPoolLeft.GetEnemyBullet();
                        enemyBullet.transform.position = transform.position + transform.right * -0.75f;
                        enemyBullet.transform.rotation = transform.rotation;
                        enemyBullet.SetActive(true);

                        shootTimer = 0;
                    }
                    
                    
                   
                }
              

                break;

            case EnemyStates.retreat:

                if (facingRight == true)
                {
                    Vector2 retreatDirection = transform.position - player.transform.position;
                    transform.Translate(retreatDirection.normalized * 2f * Time.deltaTime);

                    float retreatAngle = Mathf.Atan2(retreatDirection.y, retreatDirection.x) * Mathf.Rad2Deg;


                    transform.rotation = Quaternion.Euler(Vector3.back * retreatAngle);

                }
                else if (facingLeft == true)
                {
                    Vector2 retreatDirection = player.transform.position - transform.position;
                    transform.Translate(retreatDirection.normalized * 2f * Time.deltaTime);

                    float retreatAngle = Mathf.Atan2(retreatDirection.y, retreatDirection.x) * Mathf.Rad2Deg;


                    transform.rotation = Quaternion.Euler(Vector3.back * retreatAngle);

                }

                if (volumeToMonitor.playerInsideVolume == false)
                {
                    //Player is not within sight
                    enemyActStates = EnemyStates.walking;


                }

                //   transform.Translate(Vector2.right * speed * Time.deltaTime);




                break;

            case EnemyStates.positioning:

                // Enemy goes to an enemy point when it loses track of player



                break;


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WaterBall")
        {
            //Enemy takes damage
            health = health - damage;
            Debug.Log("You hit enemy");
           
        }
    }
}
