using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ButtonPress buttonPress;
    private PlayerStats playerStats;
    
    public float gameTime;

    [Header("Game States")]
    public bool gameStarted = false;
    public bool gameOver = false;

    public int score;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
    void Update()
    {
        if (gameStarted)
        {
            gameTime += Time.deltaTime;
        }

        if (playerStats.health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameStarted = false;
        score = (int)gameTime + playerStats.coinCount + 5 * playerStats.enemiesKilled;
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        gameOver = true;
    }
    // if game over, final score = time + enemies killed, coins collected
}
