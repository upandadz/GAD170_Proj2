using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameManager gameManager;
    public int health = 3;
    public int coinCount = 0;
    
    // movement
    private float horizontalInput;
    private float speed = 7f;
    private float jumpForce = 40f;
    private Vector2 clampValue;
    private float maxVelocity = 100f;
    
    // states
    private bool goingRight = true;

    // groundcheck
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask wallLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!gameManager.gameStarted)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        
        if (gameManager.gameStarted)
        {
            if(Input.GetKeyDown(KeyCode.D) && CanJump()) // and touching wall
            {
                goingRight = true;
                rb.velocity = new Vector2(jumpForce, rb.velocity.y);
            }   
            if(Input.GetKeyDown(KeyCode.A) && CanJump()) // and touching wall
            {
                goingRight = false;
                rb.velocity = new Vector2(-jumpForce, rb.velocity.y);
            }
            
            // if press button down and not touching wall, hold in one spot until button up (for max amount of time)
            // change colour while doing so
        }
    }
    void FixedUpdate()
    {
        // left & right movement pre game start
        if (!gameManager.gameStarted)
        {
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }
        
        // clamps the Y velocity so it doesn't break the game
        clampValue = rb.velocity;
        clampValue.y = Mathf.Clamp(clampValue.y, -maxVelocity, maxVelocity);
        rb.velocity = clampValue;

    }

    private bool CanJump()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, transform.forward, castDistance, wallLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    /* // just to visualise the box cast distance
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
    */
}
