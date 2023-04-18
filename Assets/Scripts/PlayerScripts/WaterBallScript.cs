using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallScript : MonoBehaviour
{
    public float speed;
    public float spawnTimer;

    private PlayerObjectPool playerObjectPool;
    private PlayerObjectPoolLeft playerObjectPoolLeft;

    public bool isRightSide;
    public bool isLeftSide;

    public Animator myWaterAnimator;
    public GameObject myWaterSprite;

    // Move the bullet forward
    public void Fire()
    {

        if (isRightSide)
        {
            // Set the bullet to active
            gameObject.SetActive(true);

            // Move the bullet forward
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (isLeftSide)
        {
            // Set the bullet to active
            gameObject.SetActive(true);

            // Move the bullet forward
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
        playerObjectPool = FindObjectOfType<PlayerObjectPool>();
        playerObjectPoolLeft = FindObjectOfType<PlayerObjectPoolLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 2)
        {
            gameObject.SetActive(false);
            spawnTimer = 0;
        }
        else if (spawnTimer <= 1.9f)
        {
            gameObject.SetActive(true);
        }
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {

       

        if (collision.gameObject.tag == "Enemy")
        {
        
            gameObject.SetActive(false);


        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
     
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Ground")
        {

            gameObject.SetActive(false);           

        }
        else if (collision.gameObject.tag == "MovingPlatform")
        {

            gameObject.SetActive(false);

        }
        else if (collision.gameObject.tag == "FallingPlatform")
        {

            gameObject.SetActive(false);

        }
        else if (collision.gameObject.tag == "Goal")
        {

            gameObject.SetActive(false);

        }
    }
}
