using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTypes
{
    Melee,
    Ranged,
    Other,
    TOTAL
}

public class Spawner : MonoBehaviour
{
    public GameObject meleePrefab;
    public GameObject rangedPrefab;
    public GameObject otherPrefab;

    public void SpawnMelee()
    {
        Instantiate(meleePrefab, transform.position, Quaternion.identity);
    }

    public void SpawnRanged()
    {
        Instantiate(rangedPrefab, transform.position, Quaternion.identity);
    }

    public void SpawnOther()
    {
        Instantiate(otherPrefab, transform.position, Quaternion.identity);
    }

}
