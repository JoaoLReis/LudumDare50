using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Player player;

    void Update()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        bool didJump = Input.GetButtonDown("Jump");
        float movementVertical = Input.GetAxis("Vertical");
        
        player.playerMovement.ProcessInput(movementHorizontal, movementVertical, didJump);
    }

}