using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Steps:
// 1. Remove the MonoBehaviour inheritance
// 2. Remove the Unity lifecycle methods
// 3. Create Initialize method that takes in the starting state

public class PlayerStateMachine
{
    // Note:
    // This basically means the value is public if you want to "get" it, but private if you want to "set" it
    public PlayerState currentState { get; private set; }

    public void Initialize(PlayerState _startState)
    { 
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
