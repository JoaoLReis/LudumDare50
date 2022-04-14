using RADCharacterController;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class Enemy : MonoBehaviour, IDamageable
{
    public float health = 10;

    private Weapon gun;

    private void Awake()
    {
        gun = GetComponent<Weapon>();
        gun.Shooter = gameObject;
    }

    private void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var damageable = collisionInfo.gameObject.GetComponent<IDamageable>();
            damageable.TakeDamage(gun.damage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
            HealthExpired();
    }

    private void HealthExpired()
    {
        ++GameManager.numKills;
        Destroy(gameObject);
    }
}