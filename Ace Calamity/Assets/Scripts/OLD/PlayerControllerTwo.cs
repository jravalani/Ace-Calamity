using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControllerTwo : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] Transform groundCheck;
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float groundCheckRadius;
    [SerializeField] float wallCheckDistance;
    [SerializeField] float wallSlideSpeed;
    [SerializeField] float jumpDampning = 0.5f;


    [SerializeField] int amountOfJumps;
    int amountOfJumpsLeft;

    Vector2 moveInput;
    Rigidbody2D playerBody;
    Animator animator;

    bool isGrounded;
    bool canJump;
    bool isTouchingWalls;
    bool isWallSliding;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        amountOfJumpsLeft = amountOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        FlipSprite();
        UpdateAnimations();
        CheckIfWallSliding();

    }

    private void FixedUpdate()
    {
        CheckSurroundings();
        CheckIfCanJump();
    }

    private void UpdateAnimations()
    {
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", playerBody.velocity.y);
        animator.SetBool("isWallSliding", isWallSliding);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (canJump)
        {
            if (value.isPressed)
            {
                playerBody.velocity = new Vector2(0f, jumpForce);
                amountOfJumpsLeft--;
            }

        }
    }

    private void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, playerBody.velocity.y);
        playerBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(playerVelocity.x) > Mathf.Epsilon;
        animator.SetBool("isWalking", playerHasHorizontalSpeed);

        if (isWallSliding)
        {
            if (playerBody.velocity.y < -wallSlideSpeed)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, -wallSlideSpeed);
            }
        }

    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerBody.velocity.x), 1f);
        }
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isTouchingWalls = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround) ||
                          Physics2D.Raycast(wallCheck.position, -transform.right, wallCheckDistance, whatIsGround);
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && playerBody.velocity.y <= 0.1f)
        {
            amountOfJumpsLeft = amountOfJumps;
        }

        if (amountOfJumpsLeft >= 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void CheckIfWallSliding()
    {
        if (isTouchingWalls && !isGrounded && playerBody.velocity.y < 0f)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }

}
