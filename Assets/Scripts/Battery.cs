using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour, IDamageable
{
    public float health = 10;
    public float timeIncrease = 5;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
            HealthExpired();
    }

    private void HealthExpired()
    {
        GameManager.timeRemaining += timeIncrease;
        Destroy(gameObject);
    }
}