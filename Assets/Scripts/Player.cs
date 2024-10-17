using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    
    
    private float horizontalInput;
    private float speed = 7f;
    private float maxVelocity = 10f;
    
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if game hasn't started yet, able to move left & right
        if (rb.gravityScale == 2)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
    }
    void FixedUpdate()
    {
        // left & right movement
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        
        // clamps the Y velocity so player does not hit light speed
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }
}