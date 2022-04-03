using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;

    private Player target;

    private Transform currentPlatform;

    private float direction;

    void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Player>();    
    }

    void Start()
    {
        direction = Mathf.Sign(target.transform.position.x - transform.position.x);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.layer == LayerMask.NameToLayer("Floor") || collisionInfo.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            currentPlatform = collisionInfo.transform;
            direction *= -1;
        }
    }

    void FixedUpdate()
    {
        if(target.isDead)
            return;
            
        transform.Translate(new Vector3(direction * moveSpeed * Time.fixedDeltaTime, 0, 0));
    }
}
