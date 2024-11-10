using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 20f;
    private float timer;
    private float bulletTimer = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
        timer += Time.deltaTime;
        if (timer >= bulletTimer)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
