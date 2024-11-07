using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    public GameObject instructionsUI;
    private GameManager gameManager;
    
    public TextMeshProUGUI timerText;

    [Header("HP bar")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

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
    }
}
