using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Enemy skull
/// </summary>
public class Skull : MonoBehaviour
{
    public int health = 2;
    private int damage = 2;
    private float gravityEffector = 0.5f;
    private PrefabLists prefabLists;
    private PlayerStats playerStats;
    private ParticleSystem onDeathParticles;
    private PlayerMovement playerMovement;
    private AudioManager audioManager;
    private Animator animator;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerStats = FindObjectOfType<PlayerStats>(); // would like to be able to find a reference to player when destroyed by bullet without doing this
        prefabLists = FindObjectOfType<PrefabLists>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        onDeathParticles = prefabLists.particleSystems[0];
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            audioManager.PlaySFX(audioManager.audioList[4]);
            StartCoroutine(playDeathAnimation());
            Instantiate(onDeathParticles, transform.position, Quaternion.identity);
            playerStats.enemiesKilled++;
            if (playerMovement.gravity > 0) // ensures gravity is always increasing depending if negative or positive
            {
                playerMovement.gravity += gravityEffector;
            }
            else
            {
                playerMovement.gravity -= gravityEffector;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            playerStats.TakeDamage(damage);
        }
        else if (Other.tag == "Bullet")
        {
            TakeDamage(1);
        }

    }
    
    IEnumerator playDeathAnimation()
    {
        animator.Play("SkullDeath");
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
