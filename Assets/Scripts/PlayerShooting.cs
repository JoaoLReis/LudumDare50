using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class PlayerShooting : MonoBehaviour
{
    public Transform gunParent;

    private Gun gun;
    private bool isShooting;

    void Awake()
    {
        gun = GetComponent<Gun>();
    }

    public void AimAtMouse(Vector3 mousePosition)
    {
        mousePosition.z = 0;
        gunParent.right = mousePosition - transform.position;
    }

    public void ProcessInput(bool pressedShooting, bool releasedShooting)
    {
        Debug.Log("Shooting Pressed: " + pressedShooting + " - Released: " + releasedShooting);
        if(pressedShooting)
            SetShoot(true);
        else if(releasedShooting)
            SetShoot(false);
    }

    public void SetShoot(bool value)
    {
        isShooting = value; 
    }

    void Update()
    {
        if(isShooting)
        {
            if(gun.CanShoot())
                gun.InstantiateBullet();
        }
    }
}
