using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 5f;
    public int amountOfJumps = 1;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;
    public float wallCheckDistance = 0.5f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;

    [Header("Wall Jump State")]
    public float wallJumpVelocity = 0f;
    public float walljumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("Dash State")]
    public float dashCooldown = 1f;
    public float dashTime = 0.2f;
    public float dashVelocity = 20f;
    public float drag = 10f;
    public float dashDistance = 5f;
    // similar to variable jumpheight multiplier
    public float dashEndYMultiplier = 0.2f;
}
