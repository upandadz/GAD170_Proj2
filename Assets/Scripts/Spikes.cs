using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D Player)
    {
        player.health -= 1;
        
        player.coinCount -= 3;
        if (player.coinCount < 0)
        {
            player.coinCount = 0;
        }
        // update player health bar
    }
}
