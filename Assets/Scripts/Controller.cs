using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float moveSpeed = 1f; 
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime; 
    bool facingRight = true; //Player face right
    public bool isGrounded = false; //Contact with the ground.
    public Transform groundCheckPosition; //Does it touch the floor? (pozisyon)
    public float groundCheckRadius; //circle diameter (çap)
    public LayerMask groundCheckLayer; //ground control (layer)
     void Awake()
     {

     }   
    
    // Start is called before the first frame update
    void Start()
    {
           playerRB = GetComponent<Rigidbody2D>(); //Player to Rigidbody defined.
           playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        if (playerRB.velocity.x < 0 && facingRight) //Player facing left.
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight) //Player facing right.
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad)) //Vertical=yatay jump command
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency; //  Time.timeSinceLevelLoad: Time during the game
            Jump();
        }
        

    }
    void FixedUpdate()
    {

    }
    void HorizontalMove()
    { 
       playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y); //New Vector2 defined. 
        //The value x is set by the user to be between -1 and 1. MoveSpeed determines the value of x (player speed). 
        //The y value is assigned directly.
        //playerRB.velocity = new Vector2(Input.GetAxis("Horizontal"),);
        playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void FlipFace() //Face turn method.
    {
    facingRight = !facingRight; //toggle=gecis
    Vector3 tempLocalScale = transform.localScale; // Vector3 used to define -1 (Vector3 defined).
    tempLocalScale.x *= -1; //Scale = olcu
    transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2 (0f, jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer); //Floor ball (layer kontrol)
        playerAnimator.SetBool("isGroundedAnim", isGrounded); //isGroundedAnim is connected to is Grounded for Jump Anim.
    
    }
}
