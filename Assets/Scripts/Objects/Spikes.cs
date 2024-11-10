using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private PlayerStats player;
    
    private int damage = 1;
    private int coinsLost = 3;
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            player = Other.GetComponent<PlayerStats>();
            player.TakeDamage(damage);
            player.LoseCoins(coinsLost);
        }
    }
}
