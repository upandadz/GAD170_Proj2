using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Shoot()
    {
        audioManager.PlaySFX(audioManager.audioList[3]);
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}