using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public GameObject shooter;
    public float bulletSpeed;

    private Rigidbody2D rigidb;

    public float Damage {get; set;}

    void Awake()
    {
        rigidb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rigidb.AddForce(transform.right * bulletSpeed);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject == shooter)
            return; 
            
        IDamageable damageable = collisionInfo.gameObject.GetComponent<IDamageable>();

        if(damageable != null)
            damageable.TakeDamage(Damage);

        Destroy(gameObject);
    }
}
