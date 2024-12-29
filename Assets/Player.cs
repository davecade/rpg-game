using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Only Player has monobehaviour for state machine
public class Player : MonoBehaviour
{
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce;

    #region Components
    public Animator anim {get; private set;}
    public Rigidbody2D rb {get; private set;}

    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState {get; private set;}
    public PlayerAirState airState {get; private set;}

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

        // PlayerJumpState is expecting these valies in its constructor
        // Double quotes are used to pass the string value in C#
        // Single quotes are for characters
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");

        // PlayerAirState is expecting these valies in its constructor
        // Double quotes are used to pass the string value in C#
        // Single quotes are for characters
        airState = new PlayerAirState(this, stateMachine, "Jump"); // Note that air state is the same as jump state because they share the same animation
    }

    private void Start()
    {
        // Get the animator component from the children of the Player GameObject
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // to Start the state machine, we need to call the Initialize method
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
    }
}
