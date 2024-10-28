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

    void OnTriggerEnter2D(Collider2D Player)
    {
        if (!player.floating)
        {
            StartCoroutine(FreezePlayer());
        }
    }

    private IEnumerator FreezePlayer()
    {
        player.floating = true;
        yield return new WaitForSeconds(1f);
        // change colour of player
        player.floating = false;
    }

}
