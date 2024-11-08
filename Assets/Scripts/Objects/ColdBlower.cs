using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdBlower : MonoBehaviour
{
    private PlayerMovement player;
    private SpriteRenderer playerSpriteRenderer;
    private Rigidbody2D playerRB;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        playerRB = player.GetComponent<Rigidbody2D>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            if (!player.floating)
            {
                StartCoroutine(FreezePlayer());
            }
        }
    }

    private IEnumerator FreezePlayer()
    {
        player.frozen = true;
        playerSpriteRenderer.color = Color.cyan;
        yield return new WaitForSeconds(1f);
        playerSpriteRenderer.color = Color.white;
        player.frozen = false;
    }

}
