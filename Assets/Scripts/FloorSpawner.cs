using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor;
 
    void Start()
    {
        // do a random roll to find different prefab walls
        
        floor = GameObject.Find("Floor"); // floor can = different prefab depending on roll
    }
    
    private void OnTriggerEnter2D(Collider2D Player)
    {
        Instantiate(floor, new Vector2(transform.position.x + 29, transform.position.y), Quaternion.identity);
    }
}
