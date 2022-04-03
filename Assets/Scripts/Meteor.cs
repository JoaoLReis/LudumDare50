using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float moveSpeed;

    public GameObject explosion;

    private Vector3 target;
    private Vector3 direction;

    void Start()
    {
        target = transform.position + new Vector3(-31, -19, 0);
        direction = (target - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if((transform.position - target).magnitude < 0.5f)
        {
            GameObject go = Instantiate(explosion, target, Quaternion.identity);
            Destroy(go, 1f);
            Destroy(gameObject);
        }
    }
}
