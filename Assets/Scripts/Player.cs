using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameManager gameManager;
    public int health = 3;
    public int coinCount = 0;
    public float maxVelocity = 1000f;
    
    private float horizontalInput;
    private float speed = 7f;
    private float jumpForce = 40f;


    private bool goingRight = true;
    
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if game hasn't started yet, able to move left & right
        if (!gameManager.gameStarted)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        
        if (gameManager.gameStarted)
        {
            if(Input.GetKeyDown(KeyCode.D)) // and touching wall, change to space
            {
                goingRight = true;
                rb.velocity = new Vector2(jumpForce, rb.velocity.y);
            }   
            if(Input.GetKeyDown(KeyCode.A)) // and touching wall, change to space
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
       
        // clamp y velocity
    }
}
