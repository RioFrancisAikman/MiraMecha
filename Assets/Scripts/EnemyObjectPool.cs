using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    // Holds reference to enemyBullets GameObjects in the pool
    public List<GameObject> enemyBullets;
    public GameObject bulletPrefab;
    // Number of enemyBullets to create in pool
    public int numEnemyBullets;



    private void Awake()
    {
        // Instantiate and disable each waterBall GameObject and add it to the pool list
        enemyBullets = new List<GameObject>();
        for (int i = 0; i < numEnemyBullets; i++)
        {
            // Instantiate each GameObject using tag
            GameObject bullet = Instantiate(bulletPrefab);

            // Set the GameObject as inactivve
            bullet.SetActive(false);
            // Add enemyBullets to pool list
            enemyBullets.Add(bullet);
        }
    }

    // Get enemyBullets GameObject from pool
    public GameObject GetEnemyBullet()
    {
        foreach (GameObject obj in enemyBullets)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }


        }

        GameObject newObj = Instantiate(Resources.Load("WaterBall"), Vector2.zero, Quaternion.identity) as GameObject;
        newObj.SetActive(false);
        enemyBullets.Add(newObj);
        return newObj;
    }

    public void ReturnEnemyBullet(GameObject obj)
    {
        obj.SetActive(false);
    }

   
}
