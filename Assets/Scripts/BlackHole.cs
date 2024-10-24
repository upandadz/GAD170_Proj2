using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BlackHole : MonoBehaviour
{
    private GameManager gameManager;
    
    private Player player;
    private Rigidbody2D playerRB;
    private Transform blackHoleTransform;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        playerRB = player.GetComponent<Rigidbody2D>();
        blackHoleTransform = this.transform;
    }

    void Update()
    {
        // rotates blackhole
        transform.Rotate(Vector3.forward,-150*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        playerRB.gravityScale = 0;
        playerRB.velocity = new Vector2(0, 0);
        player.floating = true;
        // want to make it gradually go towards centre of blackhole
        playerRB.position = new Vector2(blackHoleTransform.position.x, blackHoleTransform.position.y);
        gameManager.gameOver = true;
    }
}
