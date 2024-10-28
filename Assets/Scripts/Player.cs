using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameManager gameManager;
    private SpriteRenderer spriteRenderer;
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
    private float speed = 10f;
    private Vector2 clampValue;
    private Vector2 velocity;
    private float gravity;
    private float timeToWait = 0;
    private bool canFloat = true;

    [Header("States")] 
    public bool floating = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!gameManager.gameStarted)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        
        if (gameManager.gameStarted)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (Input.GetMouseButtonDown(0) && CanJump() && !floating)
            {
                rb.gravityScale *= -1;
            }
            
            // floating 
            if (Input.GetKeyDown(KeyCode.Space) && canFloat)
            {
                canFloat = false;
                gravity = rb.gravityScale;
                velocity = rb.velocity;
                floating = true;
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                spriteRenderer.color = Color.yellow;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                timeToWait += Time.deltaTime;
                if (timeToWait > 0.5f) // stops player floating too long
                {
                    ResetMotion();
                }
            }
            // change colour while doing so
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                ResetMotion();
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
        
    }

    public bool CanJump()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, transform.up, castDistance, wallLayer))
        {
            canFloat = true;
            return true;
        }
        else
        {
            return false;
        }
    }
    
    // To visualise the box cast distance
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

    private void ResetMotion()
    {
        timeToWait = 0;
        rb.gravityScale = gravity;
        rb.velocity = velocity;
        floating = false;
        spriteRenderer.color = Color.white;
    }
}
