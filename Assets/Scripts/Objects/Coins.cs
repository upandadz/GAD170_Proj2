using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private GameObject coinInstance;
    void Start()
    {
        coinInstance = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            Other.GetComponent<PlayerStats>().coinCount++;

            if (coinInstance != null)
            {
                Destroy(coinInstance);
            }
        }
    }
}
