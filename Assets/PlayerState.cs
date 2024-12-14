using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Steps:
// 1. Remove the MonoBehaviour inheritance
// 2. Remove the Unity lifecycle methods
// 3. Add a reference to the PlayerStateMachine
// 4. Add a reference to the Player
// 5. Add a reference to the animBoolName
// 6. Add a constructor that takes in the PlayerStateMachine, Player, and animBoolName
// 7. Add the Enter, Update, and Exit methods

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    private string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    { 
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        Debug.Log("Entered State: " + animBoolName);
    }

    public virtual void Update()
    { 
        //Debug.Log("Updated State: " + animBoolName);
    }

    public virtual void Exit()
    { 
        Debug.Log("Exited State: " + animBoolName);
    }
}