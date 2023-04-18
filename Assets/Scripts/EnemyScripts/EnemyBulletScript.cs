using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed;
    public float spawnTimer;

    private EnemyObjectPool enemyObjectPool;
    private EnemyObjectPoolLeft enemyObjectPoolLeft;

    public bool isRightSide;
    public bool isLeftSide;

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
        enemyObjectPool = FindObjectOfType<EnemyObjectPool>();
        enemyObjectPoolLeft = FindObjectOfType<EnemyObjectPoolLeft>();
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
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);

        }

        if (collision.gameObject.tag == "WaterBall")
        {
            gameObject.SetActive(false);

        }


        if (collision.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);

        }

        if (collision.gameObject.tag == "Goal")
        {

            gameObject.SetActive(false);

        }
    }
}
