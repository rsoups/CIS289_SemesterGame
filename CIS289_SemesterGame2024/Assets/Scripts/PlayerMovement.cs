using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
     public float moveSpeed = 5f;
    bool isFacingRight = true;
    private bool isGrounded;
    //jump stuff
    public float jump = 15;
    public float jumpTime;
    public float fallMultiplier;
    public float jumpMultiplier;
    Vector2 vecGravity;
    float jumpCounter;
    private bool isJumping;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        flipSprite();
        Jump();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void flipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isJumping = true;
            jumpCounter = 0;
        }
        //jump multiplier / player air time
        if(rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if(jumpCounter > jumpTime)
            {
                isJumping = false;
            }
            float t = jumpCounter / jumpTime;
            float currentJump = jumpMultiplier;
            //tap jump and the player hops
            if(t > 0.5f)
            {
                currentJump = jumpMultiplier * (1 - t);
            }

            rb.velocity += vecGravity * currentJump * Time.deltaTime;
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpCounter = 0;
            //let go of jump and player falls smoother
            if(rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }

        //fall multiplier
        if(rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
