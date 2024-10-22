using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ButtonPress buttonPress;
    public Canvas uiCanvas;

    public bool gameStarted = false;

    public bool gameOver = false;
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        uiCanvas.enabled = true; // not working
    }

    private void OnTriggerExit2D(Collider2D Player)
    {
        uiCanvas.enabled = false; // by default also not working
    }
    
    // if game over, final score = time + enemies killed, coins collected
}
