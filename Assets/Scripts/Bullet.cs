using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    public float bulletSpeed;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rigidbody.AddForce(transform.right * bulletSpeed);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject);
    }
}
