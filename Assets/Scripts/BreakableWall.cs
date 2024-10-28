using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private Player player;
    private Rigidbody2D playerRB;
    private GameObject thisWall;

    void Start()
    {
        player = FindObjectOfType<Player>();
        thisWall = this.gameObject;
        playerRB = player.gameObject.GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D Player)
    {
        if (player.floating || player.coinCount == 10)
        {
            Destroy(thisWall);
        }
        else
        {
            
        }
    }
}
