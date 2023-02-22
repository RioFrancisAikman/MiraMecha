using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 boxSize;
    public float maxDistance;
    public float jumpforce = 5.0f;
    public bool isOnGround;
    public Animator myAnimator;
    private bool doubleJump;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isOnGround = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

           // myAnimator.SetBool("Jumping", true);
            rb.AddForce(transform.up * jumpforce * 10.5f, ForceMode.Impulse);
           isOnGround = false;
        }

        if (isOnGround == false)
        {
            
        }

    }

    

}

