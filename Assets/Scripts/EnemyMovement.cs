using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;

    private GameObject target;

    void Awake()
    {
        target = GameObject.FindWithTag("Player");    
    }

    void FixedUpdate()
    {
        float direction = Mathf.Sign(target.transform.position.x - transform.position.x);

        transform.Translate(new Vector3(direction * moveSpeed * Time.fixedDeltaTime, 0, 0));
    }
}
