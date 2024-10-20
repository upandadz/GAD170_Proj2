using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ButtonPress buttonPress;
    public Canvas uiCanvas;

    public bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
