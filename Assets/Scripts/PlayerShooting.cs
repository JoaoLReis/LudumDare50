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
        gun.Shooter = gameObject;
    }

    public void AimAtMouse(Vector3 mousePosition)
    {
        mousePosition.z = 0;
        gunParent.right = mousePosition - transform.position;
    }

    public void ProcessInput(bool pressedShooting, bool releasedShooting)
    {
        if(pressedShooting)
            SetShoot(true);
        else if(releasedShooting)
            SetShoot(false);
    }

    public void SetShoot(bool value)
    {
        isShooting = value; 
    }

    public void Reset()
    {
        isShooting = false;
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
