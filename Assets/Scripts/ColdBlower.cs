using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdBlower : MonoBehaviour
{
    private Player player;
    private Rigidbody2D playerRB;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D Player)
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x*0.9f, playerRB.velocity.y*0.8f);
    }
    

}
