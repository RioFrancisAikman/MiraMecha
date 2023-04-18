using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector3 boxSize;
    public float maxDistance;

    public float jumpForce;
    public float doubleJumpForce;

    public bool isOnGround;
     private bool doubleJump;
    public Animator myAnimator;
   


   // public float jumpTimer;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isOnGround = true;

        jumpForce = 230f;
        doubleJumpForce = 245f;

        if (isOnGround == true)
        {
            myAnimator.SetBool("Jumping", false);
        }
        else if (isOnGround == false)
        {
            myAnimator.SetBool("Jumping", true);
        }

        if (doubleJump == false)
        {
            myAnimator.SetBool("Jumping", false);
        }
        else if (doubleJump == true)
        {
            myAnimator.SetBool("Jumping", true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        //jumpTimer += Time.deltaTime;

        if (isOnGround == true)
        {
            myAnimator.SetBool("Jumping", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {


                 myAnimator.SetBool("Jumping", true);
                rb.AddForce(new Vector2(0f, jumpForce));


                isOnGround = false;
                doubleJump = true;
            }
           

            
        }
        else
        {
            
            if (doubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                myAnimator.SetBool("Jumping", true);
                rb.AddForce(new Vector2(0f, doubleJumpForce));
                doubleJump = false;
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

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            doubleJump = false;

        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            isOnGround = true;
            doubleJump = false;

        }

        if (collision.gameObject.tag == "FallingPlatform")
        {
            isOnGround = true;
            doubleJump = false;
        }
    }
}

