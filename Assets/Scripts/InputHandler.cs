using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Player player;

    void Update()
    {
        if(player.isDead)
            return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        float movementHorizontal = Input.GetAxis("Horizontal");
        bool didJump = Input.GetButtonDown("Jump");
        float movementVertical = Input.GetAxis("Vertical");
        bool didStartShooting = Input.GetButtonDown("Fire1");
        bool didStopShooting = Input.GetButtonUp("Fire1");
        
        player.playerMovement.ProcessInput(movementHorizontal, movementVertical, didJump);
        player.ProcessMousePos(Camera.main.ScreenToWorldPoint(mousePos));
        player.playerShooting.AimAtMouse(Camera.main.ScreenToWorldPoint(mousePos));
        player.playerShooting.ProcessInput(didStartShooting, didStopShooting);
    }

}