using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public GameObject instructionsUI;
    private GameManager gameManager;
    
    public TextMeshProUGUI timerText;

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

    void OnTriggerEnter2D(Collider2D Player)
    {
        instructionsUI.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D Player)
    {
        instructionsUI.SetActive(false);
    }
}
