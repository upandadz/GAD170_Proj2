using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private GameManager gameManager;
    
    private Player player;
    private Rigidbody2D playerRB;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    private void onTriggerEnter2D(Collider2D Player)
    {
        playerRB.gravityScale = 0; // struggling to get this to work
    }
}
