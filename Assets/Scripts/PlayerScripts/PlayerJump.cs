using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
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
        rb = GetComponent<Rigidbody2D>();
        isOnGround = true;
        
        

        if (isOnGround == true)
        {
          // myAnimator.SetBool("Jumping", false);
        }
        else if (isOnGround == false)
        {
            jumpforce = 0f;
          //  myAnimator.SetBool("Jumping", true);
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
                rb.AddForce(transform.up * jumpforce * 9f, (ForceMode2D)ForceMode.Impulse);
                /*
                if (doubleJump == true)
                {
                    rb.AddForce(transform.up * jumpforce * 18f, ForceMode.Impulse);
                    doubleJump = false;
                }
                */
                isOnGround = false;
            }
            else
            {
               
               // myAnimator.SetBool("Jumping", false);
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

    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;

        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            isOnGround = true;

        }

        if (collision.gameObject.tag == "FallingPlatform")
        {
            isOnGround = true;

        }
    }
}

