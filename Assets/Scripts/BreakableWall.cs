using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private Player player;
    private GameObject thisWall;

    void Start()
    {
        player = FindObjectOfType<Player>();
        thisWall = this.gameObject;
    }
    void OnCollisionEnter2D(Collision2D Player)
    {
        if (player.floating)
        {
            Destroy(thisWall);
        }
    }
}
