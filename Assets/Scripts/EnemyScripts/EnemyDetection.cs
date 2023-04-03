using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Material on, off;
    Renderer r;
    public bool playerInsideVolume;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Target in Sight!");
            playerInsideVolume = true;
            r.material = on;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Target Lost?");
            playerInsideVolume = false;
            r.material = off;
        }
    }
}
