using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Only Player has monobehaviour for state machine
public class Player : MonoBehaviour
{
    #region Components
    public Animator anim {get; private set;}

    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    #endregion
    // Awake is a Unity lifecycle method that is called when the script instance is being loaded
    private void Awake()
    {
        // Initialize the state machine by creating a new instance of it
        // The instance comes from the PlayerStateMachine class
        stateMachine = new PlayerStateMachine();

        // PlayerIdleState is expecting these valies in its constructor
        // Double quotes are used to pass the string value in C#
        // Single quotes are for characters
        idleState = new PlayerIdleState(this, stateMachine, "Idle");

        // PlayerMoveState is expecting these valies in its constructor
        // Double quotes are used to pass the string value in C#
        // Single quotes are for characters
        moveState = new PlayerMoveState(this, stateMachine, "Move");
    }

    private void Start()
    {
        // Get the animator component from the children of the Player GameObject
        anim = GetComponentInChildren<Animator>();

        // to Start the state machine, we need to call the Initialize method
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}
