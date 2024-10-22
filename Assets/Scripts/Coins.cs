using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private Player player;
    private GameObject coinInstance;
    void Start()
    {
        player = FindObjectOfType<Player>();
        coinInstance = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        player.coinCount++;
        if (player.coinCount > 10) // 10 is max coins to be collected
        {
            player.coinCount = 10;
            // add to score increase
        }

        if (coinInstance != null)
        {
            Destroy(coinInstance);
        }
    }
}
