using System;
using RADCharacterController;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerMovement2D))]
[RequireComponent(typeof(PlayerShooting2D))]
public class Player : MonoBehaviour, IDamageable
{
    [FormerlySerializedAs("playerMovement")] public PlayerMovement2D playerMovement2D;
    [FormerlySerializedAs("playerShooting")] public PlayerShooting2D playerShooting2D;
    public Transform gunVisual;
    public Transform playerVisual;

    public GameManager gameManager;

    public float health = 10;
    public float invulnerableGrace = 0.1f;

    public float lastDamageTakenTime;

    public bool isDead;

    public Action onLiveLost;

    private void Awake()
    {
        playerMovement2D = GetComponent<PlayerMovement2D>();
        playerShooting2D = GetComponent<PlayerShooting2D>();
    }

    private void Start()
    {
        lastDamageTakenTime = Time.timeSinceLevelLoad;
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        if (Time.timeSinceLevelLoad - lastDamageTakenTime <= invulnerableGrace)
            return;

        health -= damage;
        onLiveLost?.Invoke();
        lastDamageTakenTime = Time.timeSinceLevelLoad;

        if (health <= 0)
            HealthExpired();
    }

    public void ProcessMousePos(Vector3 mousePos)
    {
        if (isDead)
            return;

        if (mousePos.x < transform.position.x)
        {
            gunVisual.localScale = new Vector3(gunVisual.localScale.x, Mathf.Abs(gunVisual.localScale.y) * -1,
                gunVisual.localScale.z);
            playerVisual.localScale = new Vector3(Mathf.Abs(playerVisual.localScale.x) * -1,
                playerVisual.localScale.y, playerVisual.localScale.z);
        }
        else
        {
            gunVisual.localScale = new Vector3(gunVisual.localScale.x, Mathf.Abs(gunVisual.localScale.y),
                gunVisual.localScale.z);
            playerVisual.localScale = new Vector3(Mathf.Abs(playerVisual.localScale.x), playerVisual.localScale.y,
                playerVisual.localScale.z);
        }
    }

    private void HealthExpired()
    {
        isDead = true;
        gameManager.EndGame();
        playerMovement2D.Reset();
        playerShooting2D.Reset();
    }
}