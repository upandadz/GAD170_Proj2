using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    public Rigidbody2D rb;
    private Gun gun;

    private SpriteRenderer spriteRenderer;
    [Space]
    
    [Header("Ground check")]
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask wallLayer;
    
    [Header("Movement")]
    private float horizontalInput;
    private float speed = 10f;
    private Vector2 clampValue;
    private Vector2 velocity;
    public float gravity;
    private float timeToWait = 0;
    private bool canHover = true;
    private float hoverTime = 0.5f;

    [Header("States")] 
    public bool hovering = false;
    public bool frozen = false;
    
    [Header("Controls")]
    public KeyCode hoverKey = KeyCode.Space;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = GetComponent<Gun>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (!gameManager.gameStarted)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        
        if (gameManager.gameStarted && !gameManager.gameOver)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            
            // changes gravity up/down on mouse click
            if (Input.GetMouseButtonDown(0) && CanHover() && !hovering && !frozen)
            {
                audioManager.PlaySFX(audioManager.audioList[2]);
                rb.gravityScale *= -1;
            }
            
            // floating 
            if (Input.GetKeyDown(hoverKey) && canHover)
            {
                canHover = false;
                gravity = rb.gravityScale;
                velocity = rb.velocity;
                hovering = true;
                rb.gravityScale = 0; // freezes player in place
                gun.Shoot();
                rb.velocity = new Vector2(rb.velocity.x, 0);
                spriteRenderer.color = Color.yellow;
            }
            else if (Input.GetKey(hoverKey))
            {
                timeToWait += Time.deltaTime;
                if (timeToWait > hoverTime) // stops player floating too long
                {
                    ResetMotion();
                }
            }
            // change colour while doing so
            else if (Input.GetKeyUp(hoverKey))
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

    public bool CanHover()
    {
        // if player is on the ground, they can jump
        if (Physics2D.BoxCast(transform.position, boxSize, 0, transform.up, castDistance, wallLayer))
        {
            canHover = true;
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
        gun.Shoot();
        rb.gravityScale = gravity;
        rb.velocity = velocity;
        hovering = false;
        spriteRenderer.color = Color.white;
    }
}
