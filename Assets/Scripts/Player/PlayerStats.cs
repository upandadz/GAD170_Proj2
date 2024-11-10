using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Stores the player stats
/// </summary>
public class PlayerStats : MonoBehaviour
{
    public int health = 3;
    public int coinCount = 0;
    public int enemiesKilled = 0;
    public GameManager gameManager;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    /// <summary>
    /// takes damage, if health => 0, calls game over function
    /// </summary>
    /// <param name="damage">amount to damage player</param>
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(ColourChange());
        if (health <= 0)
        {
            gameManager.GameOver();
        }
    }

    /// <summary>
    /// Takes away coins from player
    /// </summary>
    /// <param name="amount">amount of coins to take away</param>
    public void LoseCoins(int amount)
    {
        coinCount -= amount;
        if (coinCount < 0)
        {
            coinCount = 0;
        }
    }

    private IEnumerator ColourChange()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
