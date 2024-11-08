using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private PlayerStats playerStats;
    private PlayerMovement playerMovement;
    private Rigidbody2D playerRB;
    private GameObject thisWall;
    private PrefabLists prefabLists;

    void Start()
    {
        prefabLists = FindObjectOfType<PrefabLists>();
        playerStats = FindObjectOfType<PlayerStats>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        thisWall = this.gameObject;
        playerRB = playerMovement.gameObject.GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            Destroy(thisWall);
            Instantiate(prefabLists.particleSystems[1], Other.transform.position, Other.transform.rotation);
            playerStats.health -= 1;
        }
        else if (Other.gameObject.tag == "Bullet")
        {
            Destroy(thisWall);
            Instantiate(prefabLists.particleSystems[1], Other.transform.position, Other.transform.rotation);
        }
    }
    // note i wanted to make this into a function but "Other" was causing issues as couldn't be used in the context of a function
    // Instantiate(prefabLists.particleSystems[1], Other.transform.position, Other.transform.rotation);
}
