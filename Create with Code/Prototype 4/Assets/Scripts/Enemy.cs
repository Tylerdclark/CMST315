using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private float deleteYValue = -10;
    private GameObject player;
    private Rigidbody enemyRB;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deleteYValue)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector3 attackVec = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(attackVec * speed);
    }
}
