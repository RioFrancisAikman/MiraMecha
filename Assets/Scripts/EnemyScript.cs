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

    public Material on, off;
    Renderer r;

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


                }
                else if (forwardTimer <= 20.0f)
                {
                    //Enemy moves right
                    transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0 * Time.deltaTime));


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

                

                if (volumeToMonitor.playerInsideVolume == false)
                {
                    //Player is not within sight
                    enemyActStates = EnemyStates.walking;


                }

                break;


        }
    }
}
