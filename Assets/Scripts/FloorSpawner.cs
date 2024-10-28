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
        int roll = Random.Range(1, 4);
        // do a random roll to find different prefab walls
        if (roll == 1)
        {
            floor = prefabs.prefabOne;
        }
        else if (roll == 2)
        {
            floor = prefabs.prefabTwo;
        }
        else if (roll == 3)
        {
            floor = prefabs.prefabThree;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D Player)
    {
        Instantiate(floor, new Vector2(transform.position.x + 29, transform.position.y), Quaternion.identity);
    }
}
