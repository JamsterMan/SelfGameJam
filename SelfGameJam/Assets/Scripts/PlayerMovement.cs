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
    public LayerMask whatIsGround2;
    private FlashLight fl;


    private float moveInput;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        fl = GetComponentInChildren<FlashLight>();

        jump = false;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (!isGrounded)
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround2);

        //move player here
        Move(moveInput * Time.fixedDeltaTime, jump);
        jump = false;

        FaceFlashLight();
    }

    private void Move(float move, bool jump)
    {
        Vector3 velocity = new Vector2(move * 10f, rBody.velocity.y);
        rBody.velocity = velocity;

        if (isGrounded && jump)
        {
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
        fl.FlipFlashLight();
    }

    private void FaceFlashLight()
    {
        if ((fl.GetFlashLightAngle() > 90 || fl.GetFlashLightAngle() < -90) && facingRight) 
        {
            Flip();
        } else if ((fl.GetFlashLightAngle() <= 90 && fl.GetFlashLightAngle() >= -90) && !facingRight) 
        {
            Flip();
        }
    }
}
