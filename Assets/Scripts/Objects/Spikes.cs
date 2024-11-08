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
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            player.health -= 1;
            player.coinCount -= 3;
            if (player.coinCount < 0) // stop coints going into the negatives
            {
                player.coinCount = 0;
            }
        }
    }
}
