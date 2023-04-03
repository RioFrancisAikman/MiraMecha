using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectPool : MonoBehaviour
{
    // Holds reference to waterBall GameObjects in the pool
    public List<GameObject> waterBalls;
    public GameObject bulletPrefab;
    // Number of waterBalls to create in pool
    public int numWaterBalls;

    

    private void Awake()
    {
        // Instantiate and disable each waterBall GameObject and add it to the pool list
        waterBalls = new List<GameObject>();
        for (int i = 0; i < numWaterBalls; i++)
        {
            // Instantiate each GameObject using tag
            GameObject bullet = Instantiate(bulletPrefab);

            // Set the GameObject as inactivve
            bullet.SetActive(false);
            // Add waterBall to pool list
            waterBalls.Add(bullet);
        }
    }

    // Get waterBall GameObject from pool
    public GameObject GetWaterBall()
    {
        foreach (GameObject obj in waterBalls)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }

           
        }

        GameObject newObj = Instantiate(Resources.Load("WaterBall"), Vector2.zero, Quaternion.identity) as GameObject;
        newObj.SetActive(false);
        waterBalls.Add(newObj);
        return newObj;
    }

    public void ReturnWaterBall(GameObject obj)
    {
        obj.SetActive(false);
    }

   
}
