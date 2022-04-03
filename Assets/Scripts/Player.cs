using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShooting))]
public class Player : MonoBehaviour, IDamageable
{
    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;
    public Transform gunVisual;
    public Transform playerVisual;

    public GameManager gameManager;

    public float health = 10;
    public float invulnerableGrace = 0.1f;

    public float lastDamageTakenTime;

    public bool isDead;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();    
        playerShooting = GetComponent<PlayerShooting>();  
    }

    void Start()
    {  
        lastDamageTakenTime = Time.timeSinceLevelLoad;
    }

    public void ProcessMousePos(Vector3 mousePos)
    {
        if(isDead)
            return;
        
        if(mousePos.x < transform.position.x)
        {
            gunVisual.localScale = new Vector3(gunVisual.localScale.x, Mathf.Abs(gunVisual.localScale.y) * -1, gunVisual.localScale.z);
            playerVisual.localScale = new Vector3(Mathf.Abs(playerVisual.localScale.x) * -1, playerVisual.localScale.y, playerVisual.localScale.z);
        }
        else
        {
            gunVisual.localScale = new Vector3(gunVisual.localScale.x, Mathf.Abs(gunVisual.localScale.y), gunVisual.localScale.z);
            playerVisual.localScale = new Vector3(Mathf.Abs(playerVisual.localScale.x), playerVisual.localScale.y, playerVisual.localScale.z);
        }
    }

    public void TakeDamage(float damage)
    {
        if(isDead)
            return;

        if(Time.timeSinceLevelLoad - lastDamageTakenTime <= invulnerableGrace)
            return;

        health -= damage;
        lastDamageTakenTime = Time.timeSinceLevelLoad;
        
        if(health <= 0)
            HealthExpired();
    }

    private void HealthExpired()
    {
        isDead = true;
        GameManager.isCountingTime = false;
        gameManager.EndGame();
        playerMovement.Reset();
        playerShooting.Reset();
    }

}
