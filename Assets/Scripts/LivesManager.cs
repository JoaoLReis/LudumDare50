using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public GameObject[] lives;

    public Player player;

    void Start()
    {
        UpdateLives();
        player.onLiveLost += UpdateLives;
    }

    private void UpdateLives()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].SetActive(player.health >= i + 1);
        }
    }

}
