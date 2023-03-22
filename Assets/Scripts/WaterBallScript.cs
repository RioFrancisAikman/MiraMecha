using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallScript : MonoBehaviour
{
    public float speed;
    private PlayerObjectPool playerObjectPool;

    // Move the bullet forward
    public void Fire()
    {
        // Set the bullet to active
        gameObject.SetActive(true);

        // Move the bullet forward
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
        playerObjectPool = FindObjectOfType<PlayerObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);

        }


        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);

        }
    }
}
