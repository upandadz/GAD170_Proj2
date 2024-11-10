using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UI : MonoBehaviour
{
    private GameManager gameManager;
    [Header("UI Elements")]
    public GameObject instructionsUI;
    public GameObject gameOverUI;
    private CanvasGroup gameOverCanvasGroup;
    
    [Header("Scores")] 
    public TMP_Text currentScore;
    public TMP_Text highScore;
    public TextMeshProUGUI timerText;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameOverCanvasGroup = gameOverUI.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        // timer display
        if (gameManager.gameStarted)
        {
            timerText.text = gameManager.gameTime.ToString("00.00");
        }
    }
    
    /// <summary>
    /// Deletes the high score & sets it to 0
    /// </summary>
    public void DeleteScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        gameManager.score = 0;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    
    /// <summary>
    /// Loads the start game scene
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void DisplayGameOver()
    {
        currentScore.text = gameManager.score.ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        gameOverUI.SetActive(true);
        gameOverCanvasGroup.DOFade(1, 2);
    }
}
