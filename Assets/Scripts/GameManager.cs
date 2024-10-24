using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ButtonPress buttonPress;

    [Header("Game States")]
    public bool gameStarted = false;
    public bool gameOver = false;

    public float gameTime;
    void Update()
    {
        if (gameStarted)
        {
            gameTime += Time.deltaTime;
        }
    }
    // if game over, final score = time + enemies killed, coins collected
}
