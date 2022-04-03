using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShower : MonoBehaviour
{
    public GameObject[] meteors;

    public void StartMeteorShower()
    {
        for (int i = 0; i < meteors.Length; i++)
        {
            meteors[i].SetActive(true);
        }
    }
}
