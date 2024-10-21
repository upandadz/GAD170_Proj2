using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Rigidbody2D player;
    private GameManager gameManager;

    public bool startPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        gameManager.gameStarted = true;
        player.gravityScale = -1;
    }
}
