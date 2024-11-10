using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdBlower : MonoBehaviour
{
    private PlayerMovement player;
    private SpriteRenderer playerSpriteRenderer;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.audioList[1]);
            player = Other.GetComponent<PlayerMovement>();
            playerSpriteRenderer = Other.GetComponent<SpriteRenderer>();
            if (!player.hovering)
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
