using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private PlayerStats player;
    private GameObject coinInstance;
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        coinInstance = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        player.coinCount++;

        if (coinInstance != null)
        {
            Destroy(coinInstance);
        }
    }
}
