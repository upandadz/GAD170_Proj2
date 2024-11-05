using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    [Header("Health")]
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Image[] hearts;
    
    [Header("Coins")]
    public TMP_Text coinText;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    void Update()
    {
        // health display
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerStats.health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        
        //coin display
        coinText.text = playerStats.coinCount.ToString();
    }
}
