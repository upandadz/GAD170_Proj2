using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    public Rigidbody2D player;
    private GameManager gameManager;

    public bool startPressed = false;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        gameManager.gameStarted = true;
    }
}
