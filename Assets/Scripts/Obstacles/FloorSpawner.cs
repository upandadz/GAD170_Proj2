using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor;
    private PrefabLists prefabs;
 
    void Start()
    {
        prefabs = FindObjectOfType<PrefabLists>();
        int roll = Random.Range(0, prefabs.obstaclePrefabs.Count);
        floor = prefabs.obstaclePrefabs[roll];
        
    }
    
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            Instantiate(floor, new Vector2(transform.position.x + 29, transform.position.y), Quaternion.identity);
        }
    }
}
