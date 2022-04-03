using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public float timeBetweenMeleeSpawnMax = 1f;
    public float timeBetweenRangedSpawnMax = 2.5f;
    public float timeBetweenOtherSpawnMax = 4.5f;

    private float timeBetweenMeleeSpawn = 1f;
    private float timeBetweenRangedSpawn = 2.5f;
    private float timeBetweenOtherSpawn = 4.5f;

    public float stepIncrease = 0.1f;
    public float timeBetweenIncrease = 10f;

    public float distanceToSpawn = 15;

    public Spawner[] spawners;
    public Player player;

    private float timeSinceMeleeSpawn = 0;
    private float timeSinceRangedSpawn = 0;
    private float timeSinceOtherSpawn = 0;

    void Start()
    {
        timeBetweenMeleeSpawn = timeBetweenMeleeSpawnMax;
        timeBetweenRangedSpawn = timeBetweenRangedSpawnMax;
        timeBetweenOtherSpawn = timeBetweenOtherSpawnMax;
    }

    void Update()
    {
        if(player.isDead)
            return;
            
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

        UpdateSpawnTimes();
    }

    private void Spawn(EnemyTypes types)
    {
        Spawner[] availableSpawners = GetAvailableSpawners();
        int rand = UnityEngine.Random.Range((int)0, (int)availableSpawners.Length-1);

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

    private void UpdateSpawnTimes()
    {
        timeBetweenMeleeSpawn = Mathf.Max(0.5f, timeBetweenMeleeSpawnMax - (stepIncrease * (GameManager.timeSinceGameStart/timeBetweenIncrease)));
        timeBetweenRangedSpawn = Mathf.Max(0.5f, timeBetweenRangedSpawnMax - (stepIncrease * (GameManager.timeSinceGameStart/timeBetweenIncrease)));
        timeBetweenOtherSpawn = Mathf.Max(0.5f, timeBetweenOtherSpawnMax - (stepIncrease * (GameManager.timeSinceGameStart/timeBetweenIncrease)));
    }    
}
