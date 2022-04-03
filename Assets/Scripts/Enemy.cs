using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class Enemy : MonoBehaviour, IDamageable
{
    public float health = 10;

    private Gun gun;

    void Awake()
    {
        gun = GetComponent<Gun>();
        gun.Shooter = gameObject;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
            HealthExpired();
    }

    private void HealthExpired()
    {
        ++GameManager.numKills;
        Destroy(gameObject);
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            IDamageable damageable = collisionInfo.gameObject.GetComponent<IDamageable>();
            damageable.TakeDamage(gun.damage);
        }
    }
}
