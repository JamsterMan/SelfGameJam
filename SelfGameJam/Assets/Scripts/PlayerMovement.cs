using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    public float jumpForce;


    private Rigidbody2D rBody;
    private bool facingRight;

    private bool jump;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private float moveInput;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();

        jump = false;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //move player here
        Move(moveInput * Time.fixedDeltaTime, jump);
        jump = false;
    }

    private void Move(float move, bool jump)
    {
        Vector3 velocity = new Vector2(move * 10f, rBody.velocity.y);
        rBody.velocity = velocity;

        if(!facingRight && moveInput > 0) {//moving right but facing left
            Flip();
        }else if (facingRight && moveInput < 0) {//moving left but faceing right
            Flip();
        }

        if(isGrounded && jump) {
            isGrounded = false;
            rBody.AddForce(new Vector2(0, jumpForce));
        }
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
