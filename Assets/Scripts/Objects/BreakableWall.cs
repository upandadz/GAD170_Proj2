using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private GameObject thisWall;
    private PrefabLists prefabLists;
    private int damage = 1;
    private AudioManager audioManager;

    void Start()
    {
        prefabLists = FindObjectOfType<PrefabLists>();
        audioManager = FindObjectOfType<AudioManager>();
        thisWall = this.gameObject;
    }
    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            Other.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            DestroyWall(Other.gameObject);
        }
        else if (Other.gameObject.tag == "Bullet")
        {
            DestroyWall(Other.gameObject);
        }
    }

    /// <summary>
    /// Destroys wall
    /// </summary>
    /// <param name="collider">whatever object collides with the wall</param>
    void DestroyWall(GameObject collider)
    {
        Destroy(thisWall);
        Instantiate(prefabLists.particleSystems[1], collider.transform.position, collider.transform.rotation);
        audioManager.PlaySFX(audioManager.audioList[5]);
    }
}
