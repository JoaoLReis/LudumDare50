using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public float attackSpeed;
    public GameObject prefab;
    public Transform gunEnd;

    private float lastShotTime;

    public GameObject Shooter {get; set;}

    void Awake()
    {
        lastShotTime = Time.timeSinceLevelLoad;
    }

    public bool CanShoot()
    {
        return Time.timeSinceLevelLoad - lastShotTime >= attackSpeed;
    }

    public void InstantiateBullet()
    {
        lastShotTime = Time.timeSinceLevelLoad;
        GameObject go = Instantiate(prefab, gunEnd.position, gunEnd.rotation);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.shooter = Shooter;
        bullet.Damage = damage;
        Destroy(go, 2f);
    }
}
