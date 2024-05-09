using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, -90);
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    // public void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Enemy"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
