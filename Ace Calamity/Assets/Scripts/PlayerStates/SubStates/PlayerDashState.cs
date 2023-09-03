using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash { get; private set; }

    private Vector2 dashDirection;

    private float lastDashTime;
    private bool dashInputStop;
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        CanDash = false;
        dashDirection = Vector2.right * player.FacingDirection;
    }


    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            dashInputStop = player.InputHandler.DashInputStop;

            if (!dashInputStop)
            {
                // Start the dash coroutine when the player initiates the dash
                player.StartCoroutine(DashCoroutine());
            }
        }
    }



    // below functin will return true if
    // canDash is true which is going to get set when the player enters the grounded state
    // and our cooldown has run out;
    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    public void ResetCanDash()
    {
        CanDash = true;
    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time;
        float endTime = startTime + playerData.dashTime;
        float dashDistance = 0f; // Tracks the distance covered during the dash

        // Store the player's position before dashing
        Vector2 startPosition = player.transform.position;

        // Execute the dash movement while the time is within the dash duration and the dash distance is within the allowed range
        while (Time.time < endTime && dashDistance < playerData.dashDistance)
        {
            // Calculate the remaining distance to dash
            dashDistance = Vector2.Distance(player.transform.position, startPosition);

            // Set the player's velocity to the dash velocity in the dashDirection
            player.RB.velocity = dashDirection * playerData.dashVelocity;

            yield return null; // This will make the coroutine wait for the next frame.
        }

        // After the dash is done, reset the player's velocity
        player.RB.velocity = Vector2.zero;

        // Mark the ability as done
        isAbilityDone = true;
        lastDashTime = Time.time;
    }


}

