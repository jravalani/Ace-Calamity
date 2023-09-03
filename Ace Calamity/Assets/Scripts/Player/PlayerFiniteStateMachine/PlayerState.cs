using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected float startTime;

    private string animBoolName;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    //enter is called when we enter a state
    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        Debug.Log(animBoolName);
        isAnimationFinished = false;
        isExitingState = false;
    }

    // exit is called when we exit a state
    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }
    // logicupdate == update, logicupdate is called every frame
    public virtual void LogicUpdate()
    {

    }

    //physicsupdate == fixedupdate, physicsupdate is called every fixedupdate
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    // do checks is a function that we are going to call from physicsupdate and from enter.
    // in this function we are going to look for walls, look for ground and things like that.
    // that way we don't have to call them inside physicsupdate and enter 
    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger()
    {

    }

    public virtual void AnimationFinishedTrigger()
    {
        isAnimationFinished = true;
    }
}
