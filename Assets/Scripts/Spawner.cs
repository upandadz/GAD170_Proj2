using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Object spawnObject;

    private int spawnRoll;

    void Start()
    {
        spawnRoll = Random.Range(1, 3);
    }

}
