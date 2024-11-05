using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private PlayerStats player;
    private GameManager gameManager;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D Player)
    {
        player.health -= 1;
        if (player.health <= 0)
        {
            gameManager.gameOver = true;
        }
        
        player.coinCount -= 3;
        if (player.coinCount < 0)
        {
            player.coinCount = 0;
        }
        // update player health bar
    }
}
