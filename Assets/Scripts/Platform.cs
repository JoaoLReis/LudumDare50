using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PlatformEffector2D effector2D;

    void Awake()
    {
        effector2D = GetComponent<PlatformEffector2D>();
    }
}
