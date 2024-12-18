using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Saw : MonoBehaviour
{
    private GameManager gameManager;
    
    private PlayerMovement player;
    private Rigidbody2D playerRB;
    private Transform sawTransform;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerMovement>();
        playerRB = player.GetComponent<Rigidbody2D>();
        sawTransform = this.transform;
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            playerRB.gravityScale = 0;
            // want to make it gradually go towards centre of saw & camera shake
            playerRB.position = new Vector2(sawTransform.position.x, sawTransform.position.y);
            gameManager.GameOver();
        }
    }
}
