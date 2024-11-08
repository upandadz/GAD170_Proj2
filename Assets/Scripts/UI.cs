using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject instructionsUI;
    private GameManager gameManager;
    
    public TextMeshProUGUI timerText;

    [Header("Scores")] 
    public TMP_Text currentScore;
    public TMP_Text highScore;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.gameStarted)
        {
            timerText.text = gameManager.gameTime.ToString("00.00");
        }

        if (gameManager.gameOver)
        {
            currentScore.text = gameManager.score.ToString();
            highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }

    public void DeleteHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartGame");
    }
    
    // DOTween to fade in
}
