using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum EnemyStates { walking, chasing }
    public EnemyStates enemyActStates;

    public GameObject player;
    public float speed = 1;

    public EnemyDetection volumeToMonitor;

    public float forwardTimer;

    public float shootTimer;

    public Material on, off;
    Renderer r;

    public GameObject myEnemySprite;

    public Transform shooting1SpawnPoint;
    public GameObject myEnemy1ObjectToSpawn;
    public Transform shooting2SpawnPoint;
    public GameObject myEnemy2ObjectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();

        speed = 2.0f;

        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyActStates)
        {
            case EnemyStates.walking:

                //Enemy is calm
                r.material = off;

                forwardTimer += Time.deltaTime;


                if (forwardTimer <= 10.0f)
                {
                    //Enemy moves left
                    transform.Translate(new Vector3(1 * Time.deltaTime, 0, 0 * Time.deltaTime));
                    myEnemySprite.transform.localScale = new Vector3(-1.75f, 1.75f, 1.75f);

                }
                else if (forwardTimer <= 20.0f)
                {
                    //Enemy moves right
                    transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0 * Time.deltaTime));
                    myEnemySprite.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

                }
                else
                {
                    // resets timer
                    forwardTimer = 0;
                }


                if (volumeToMonitor.playerInsideVolume == true)
                {
                    //Player is within sight
                    enemyActStates = EnemyStates.chasing;


                }

                break;

            case EnemyStates.chasing:

                // Enemy becomes angry
                r.material = on;


                shootTimer += Time.deltaTime;

                if (volumeToMonitor.playerInsideVolume == false)
                {
                    //Player is not within sight
                    enemyActStates = EnemyStates.walking;


                }

               

                if (shootTimer >= 3.0f)
                {

                    if (forwardTimer >= 10.0f)
                    {
                        GameObject EnemyShot = Instantiate(myEnemy1ObjectToSpawn, shooting1SpawnPoint.position, Quaternion.identity) as GameObject;
                        Rigidbody sr = EnemyShot.GetComponent<Rigidbody>();

                        //  Debug.Break();
                        sr.AddRelativeForce(Vector3.left * 150);

                        shootTimer = 0;
                    }
                    else if (forwardTimer >= 20.0f)
                    {
                        GameObject EnemyShot = Instantiate(myEnemy2ObjectToSpawn, shooting2SpawnPoint.position, Quaternion.identity) as GameObject;
                        Rigidbody sr = EnemyShot.GetComponent<Rigidbody>();

                        //  Debug.Break();
                        sr.AddRelativeForce(Vector3.right * 150);

                        shootTimer = 0;
                    }

                   
                }

                break;

           

                

               


              

               
        }
    }
}
