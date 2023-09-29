using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Animator animator;
    private float movementInputDirection;

    private int amountOfJumpsLeft;
    public int amountOfJumps = 1;

    public float movementSpeed = 5f;
    public float jumpForce = 16f;
    public float groundCheckRadius;
    public float wallCheckDistance;

    private bool isFacingRight = true;
    private bool isWalking;
    private bool isGrounded;
    private bool canJump;
    private bool isTouchingWalls;

    public LayerMask whatIsGround;

    public Transform groundCheck;
    public Transform wallCheck;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        amountOfJumpsLeft = amountOfJumps;
        Debug.Log(amountOfJumpsLeft);
    }

    private void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        CheckSurroundings();
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isTouchingWalls = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
    }
    private void CheckMovementDirection()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerBody.velocity.x) > Mathf.Epsilon;
        if (isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        if (playerBody.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void CheckIfCanJump()
    {
        // If the player is on the ground, reset the amount of jumps left
        if (isGrounded && playerBody.velocity.y <= 0.1)
        {
            amountOfJumpsLeft = amountOfJumps;
        }
        // Allow the player to jump again if they have jumps left
        if (amountOfJumpsLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }


    private void UpdateAnimations()
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", playerBody.velocity.y);
    }
    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Jump();
        }
    }

    private void Jump()
    {
        Debug.Log("Jump called");
        if (canJump)
        {
            Debug.Log(amountOfJumpsLeft);
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
            amountOfJumpsLeft--;
            Debug.Log(amountOfJumpsLeft);
        }
    }


    private void MovePlayer()
    {
        playerBody.velocity = new Vector2(movementInputDirection * movementSpeed, playerBody.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }


}
