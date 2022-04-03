using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public float timeBetweenMeleeSpawn = 0.5f;
    public float timeBetweenRangedSpawn = 1.5f;
    public float timeBetweenOtherSpawn = 3.5f;

    public float distanceToSpawn = 15;

    public Spawner[] spawners;
    public GameObject player;

    private float timeSinceMeleeSpawn = 0;
    private float timeSinceRangedSpawn = 0;
    private float timeSinceOtherSpawn = 0;

    void Update()
    {
        timeSinceMeleeSpawn += Time.deltaTime;
        timeSinceRangedSpawn += Time.deltaTime;
        timeSinceOtherSpawn += Time.deltaTime;

        if(timeSinceMeleeSpawn >= timeBetweenMeleeSpawn)
        {
            Spawn(EnemyTypes.Melee);
            timeSinceMeleeSpawn = 0;
        }
        if(timeSinceRangedSpawn >= timeBetweenRangedSpawn)
        {
            Spawn(EnemyTypes.Ranged);
            timeSinceRangedSpawn = 0;
        }
        if(timeSinceOtherSpawn >= timeBetweenOtherSpawn)
        {
            Spawn(EnemyTypes.Other);
            timeSinceOtherSpawn = 0;
        }
    }

    private void Spawn(EnemyTypes types)
    {
        Spawner[] availableSpawners = GetAvailableSpawners();
        int rand = UnityEngine.Random.Range((int)0, (int)availableSpawners.Length);

        switch (types)
        {
            case EnemyTypes.Melee:
                availableSpawners[rand].SpawnMelee();
                break;
            case EnemyTypes.Ranged:
                availableSpawners[rand].SpawnRanged();
                break;
            case EnemyTypes.Other:
                availableSpawners[rand].SpawnOther();
                break;
            default:
                break;
        }
    }

    private Spawner[] GetAvailableSpawners()
    {
        List<Spawner> availableSpawners = new List<Spawner>();

        for (int i = 0; i < spawners.Length; i++)
        {
            Spawner spawner = spawners[i];
            if(Vector2.Distance(spawner.transform.position, player.transform.position) >= distanceToSpawn)
            {
                availableSpawners.Add(spawner);
            }
        }

        return availableSpawners.ToArray();
    }    
}