using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject instructionUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        instructionUI.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        instructionUI.SetActive(false);
    }
}
