using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{

    public GameObject walls;
 
    void Start()
    {
        // do a random roll to find different prefab walls
        
        walls = GameObject.Find("Walls"); // walls can = different prefab depending on roll
    }
    
    private void OnTriggerEnter2D(Collider2D Player)
    {
        Instantiate(walls, new Vector2(-9, transform.position.y + 12), Quaternion.identity);
    }
}
