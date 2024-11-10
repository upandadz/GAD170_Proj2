using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public PlayerMovement player;
    public int cameraXOffset;
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + cameraXOffset, transform.position.y, transform.position.z);
    }
}
