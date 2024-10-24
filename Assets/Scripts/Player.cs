using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameManager gameManager;
    [Space]
    [Header("Player Stats")]
    public int health = 3;
    public int coinCount = 0;
    
    [Header("Ground check")]
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask wallLayer;
    
    [Header("Movement")]
    private float horizontalInput;
    private float speed = 7f;
    private float jumpForce = 40f;
    private Vector2 clampValue;
    private float maxVelocity = 10f;
    private Vector2 velocity;
    private float timeToWait = 0;

    [Header("States")] 
    public bool floating = false;
    private bool goingRight = true;


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
            // right jump
            if(Input.GetKeyDown(KeyCode.D) && CanJump())
            {
                goingRight = true;
                rb.velocity = new Vector2(jumpForce, rb.velocity.y);
            }   
            // left jump
            if(Input.GetKeyDown(KeyCode.A) && CanJump())
            {
                goingRight = false;
                rb.velocity = new Vector2(-jumpForce, rb.velocity.y);
            }

            if (goingRight && rb.velocity.x == 0 && !floating)
            {
                rb.velocity = new Vector2(jumpForce, rb.velocity.y);
            }

            if (!goingRight && rb.velocity.x == 0 && !floating)
            {
                rb.velocity = new Vector2(-jumpForce, rb.velocity.y);
            }
            
            // floating 
            if ((rb.velocity.x > 0 || rb.velocity.x < 0) && Input.GetKeyDown(KeyCode.Space))
            {
                velocity = rb.velocity;
                floating = true;
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                timeToWait += Time.deltaTime;
                if (timeToWait > 0.4f) // stops player floating too long
                {
                    timeToWait = 0;
                    rb.velocity = velocity;
                    floating = false;
                }
            }
            // change colour while doing so
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                timeToWait = 0;
                rb.velocity = velocity;
                floating = false;
            }
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

    public bool CanJump()
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }

    /* // just to visualise the box cast distance
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
    */
}
