using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private PlayerStats playerStats;
    private PlayerMovement playerMovement;
    private Rigidbody2D playerRB;
    private GameObject thisWall;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        thisWall = this.gameObject;
        playerRB = playerMovement.gameObject.GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D Player)
    {
        if (playerMovement.floating || playerStats.coinCount == 10)
        {
            Destroy(thisWall);
        }
        else
        {
            Destroy(thisWall);
            playerStats.health -= 1;
        }
    }
}
