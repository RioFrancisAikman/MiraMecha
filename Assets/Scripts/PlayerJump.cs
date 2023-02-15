using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 boxSize;
    public float maxDistance;
    public float jumpforce = 2.5f;
    public bool isGrounded;

    [SerializeField]
    private int maxJumps = 2;
    private int _jumpsLeft;
    private Rigidbody _rigidbody;
    private Transform groundCheck;

    [SerializeField]
    private float groundCheckRadius = 0.05f;

    [SerializeField]
    private LayerMask collisionMask;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;

        _jumpsLeft = maxJumps;

        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var jumpInput = Input.GetKeyDown(KeyCode.Space);

        if ( _rigidbody.velocity.y <= 0)
        {
            _jumpsLeft = maxJumps;
        }



        if(jumpInput && _jumpsLeft > 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, y: jumpforce);
            _jumpsLeft -= 1;
            isGrounded=false;
        }


        if (isGrounded == false)
        {
            jumpforce = 0f;
        }
       
    }


}


