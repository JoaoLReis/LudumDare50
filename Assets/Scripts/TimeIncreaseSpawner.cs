using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeIncreaseSpawner : MonoBehaviour
{
    public float timeBetweenSpawnMax = 4f;

    private float timeBetweenSpawn = 1f;

    public float stepDecrease = 1f;
    public float timeBetweenDecrease = 10f;

    public float distanceToSpawn = 15;

    public Transform[] spawners;
    public Player player;
    public GameObject timeIncreasePrefab;

    private float timeSinceSpawn = 0;

    private bool isSpawning = true;

    void Start()
    {
        timeBetweenSpawn = timeBetweenSpawnMax;
    }

    void Update()
    {
        if(player.isDead)
            return;

        if(!isSpawning)
            return;

        timeSinceSpawn += Time.deltaTime;

        if(timeSinceSpawn >= timeBetweenSpawn)
        {
            Spawn();
            timeSinceSpawn = 0;
        }

        UpdateSpawnTimes();
    }

    private void Spawn()
    {
        isSpawning = false;
        Transform[] availableSpawners = GetAvailableSpawners();
        int rand = UnityEngine.Random.Range((int)0, (int)availableSpawners.Length-1);

        Battery battery = Instantiate(timeIncreasePrefab, availableSpawners[rand].position, Quaternion.identity).GetComponent<Battery>();
        battery.onDestroy += ResetSpawning;
    }

    private void ResetSpawning()
    {
        isSpawning = true;
    }

    private Transform[] GetAvailableSpawners()
    {
        List<Transform> availableSpawners = new List<Transform>();

        for (int i = 0; i < spawners.Length; i++)
        {
            Transform spawner = spawners[i];
            if(Vector2.Distance(spawner.transform.position, player.transform.position) >= distanceToSpawn)
            {
                availableSpawners.Add(spawner);
            }
        }

        return availableSpawners.ToArray();
    }

    private void UpdateSpawnTimes()
    {
        timeBetweenSpawn = timeBetweenSpawnMax + (stepDecrease * (GameManager.timeSinceGameStart/timeBetweenDecrease));
    }    
}
