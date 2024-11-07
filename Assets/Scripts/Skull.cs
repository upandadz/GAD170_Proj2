using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public int health = 2;
    private PrefabLists prefabLists;
    private PlayerStats playerStats;
    private ParticleSystem onDeathParticles;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        prefabLists = FindObjectOfType<PrefabLists>();
        onDeathParticles = prefabLists.particleSystems[0];
        // get reference to on death explosion
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(onDeathParticles, transform.position, Quaternion.identity);
            playerStats.enemiesKilled++;
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            playerStats.health -= 2;
        }
        else if (Other.tag == "Bullet")
        {
            TakeDamage(1);
        }

    }
}
