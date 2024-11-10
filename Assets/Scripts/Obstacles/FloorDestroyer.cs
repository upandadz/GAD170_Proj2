using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class FloorDestroyer : MonoBehaviour
{
    private GameObject floor;

    private void Start()
    {
        floor = transform.parent.gameObject;
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            Destroy(floor);
        }
    }
}
