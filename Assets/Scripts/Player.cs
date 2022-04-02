using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShooting))]
public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();    
        playerShooting = GetComponent<PlayerShooting>();    
    }

}
