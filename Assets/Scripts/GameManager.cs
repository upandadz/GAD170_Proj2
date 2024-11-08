using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ButtonPress buttonPress;
    private PlayerStats playerStats;
    private PlayerMovement playerMovement;
    
    public float gameTime;

    [Header("Game States")]
    public bool gameStarted = false;
    public bool gameOver = false;

    public int score;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        if (gameStarted && !gameOver)
        {
            gameTime += Time.deltaTime;
        }

        if (playerStats.health <= 0)
        {
            GameOver();
        }

        if (gameOver)
        {
            playerMovement.rb.velocity = new Vector2(0, 0);
        }
    }

    public void GameOver()
    {
        score = (int)gameTime + playerStats.coinCount + 5 * playerStats.enemiesKilled;
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        gameOver = true;
    }
}
