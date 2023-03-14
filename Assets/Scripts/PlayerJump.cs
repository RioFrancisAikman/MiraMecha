using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 boxSize;
    public float maxDistance;
    public float jumpforce = 0.5f;
    public bool isOnGround;
    public Animator myAnimator;
    private bool doubleJump;

   // public float jumpTimer;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isOnGround = true;
        
        if (isOnGround == false)
        {
            jumpforce = 0f;

           

        }
       
    }

    // Update is called once per frame
    void Update()
    {

        //jumpTimer += Time.deltaTime;

        if (isOnGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                // myAnimator.SetBool("Jumping", true);
                rb.AddForce(transform.up * jumpforce * 9f, ForceMode.Impulse);
                isOnGround = false;
            }
        }
        /*
        else if (isOnGround == false && jumpTimer >= 1.5)
        {
            isOnGround = true;
            jumpTimer = 0;
        }
      */

       

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

}

