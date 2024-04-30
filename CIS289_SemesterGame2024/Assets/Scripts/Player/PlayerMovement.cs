using System;
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
    //animation stuff
    public Animator animator;

    //private float idleBlink = 0f;
    // private IEnumerator BlinkCoroutine;
    //private PlayerCombat attack;

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

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // if(Mathf.Abs(horizontalInput) <= 0 || attack)
        // {
        //     if(Time.time > idleBlink)
        //     {
        //         BlinkCoroutine = Blink();
        //         StartCoroutine(BlinkCoroutine);
        //     }
        // }

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

            transform.Rotate(0f, 180f, 0f);
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

    // private IEnumerator Blink()
    // {
    //     animator.Play("Player_blink");
    //     yield return new WaitForSeconds(0.2f);

    //     animator.Play("Player_idle");
    //     idleBlink = Time.time + Random.Range(0.2f, 5f);
    // }

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
