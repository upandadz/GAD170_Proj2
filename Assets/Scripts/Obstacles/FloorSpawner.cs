using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor;
    private ObstaclePrefabs prefabs;
 
    void Start()
    {
        prefabs = FindObjectOfType<ObstaclePrefabs>();
        int roll = Random.Range(0, prefabs.prefabs.Count);
        floor = prefabs.prefabs[roll];
        
    }
    
    private void OnTriggerEnter2D(Collider2D Player)
    {
        Instantiate(floor, new Vector2(transform.position.x + 29, transform.position.y), Quaternion.identity);
    }
}
