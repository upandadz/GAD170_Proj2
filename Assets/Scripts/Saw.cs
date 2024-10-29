using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Saw : MonoBehaviour
{
    private GameManager gameManager;
    
    private Player player;
    private Rigidbody2D playerRB;
    private Transform sawTransform;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        playerRB = player.GetComponent<Rigidbody2D>();
        sawTransform = this.transform;
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        gameManager.gameStarted = false;
        playerRB.gravityScale = 0;
        playerRB.velocity = new Vector2(0, 0);
        // want to make it gradually go towards centre of saw & camera shake
        playerRB.position = new Vector2(sawTransform.position.x, sawTransform.position.y);
        gameManager.gameOver = true;
    }
}
