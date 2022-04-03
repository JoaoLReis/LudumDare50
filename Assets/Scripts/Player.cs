using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShooting))]
public class Player : MonoBehaviour, IDamageable
{
    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    public float health = 10;
    public float invulnerableGrace = 0.1f;

    public float lastDamageTakenTime;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();    
        playerShooting = GetComponent<PlayerShooting>();    
        lastDamageTakenTime = Time.timeSinceLevelLoad;
    }

    public void TakeDamage(float damage)
    {
        if(Time.timeSinceLevelLoad - lastDamageTakenTime <= invulnerableGrace)
            return;

        health -= damage;
        lastDamageTakenTime = Time.timeSinceLevelLoad;
        
        if(health <= 0)
            HealthExpired();
    }

    private void HealthExpired()
    {
        Destroy(gameObject);
    }

}
