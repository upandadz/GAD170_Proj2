using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameManager gameManager;
    public int health = 3;
    public int coinCount = 0;
    public float maxVelocity = 10f;
    
    private float horizontalInput;
    private float speed = 7f;


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
    }
    void FixedUpdate()
    {
        // left & right movement pre game start
        if (!gameManager.gameStarted)
        {
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }

        // clamps the Y velocity so player does not hit light speed
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        
        // if game has started, press spacebar to change direction
        if (gameManager.gameStarted)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                goingRight = true;
                // rb.velocity = new Vector2(-500, rb.velocity.y); // not working as intended
                // Physics2D.gravity = new Vector2(10, -1);
                rb.velocity = new Vector2(1f * speed, rb.velocity.y); // not quite working
            }   
            else if(Input.GetKeyDown(KeyCode.A))
            {
                goingRight = false;
                // rb.velocity = new Vector2(500, rb.velocity.y); // not working as intended
                // Physics2D.gravity = new Vector2(10, -1);
                rb.velocity = new Vector2(-1f * speed, rb.velocity.y); // not quite working
            }
        }
    }
}
