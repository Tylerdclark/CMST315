using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private GameObject player;
    private Rigidbody objectRB;
    public float speed = 5.0f;
    private const float zLimit = 10.0f;
    private const float TimeLimit = 12.0f;
    private float timeStart;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        objectRB = GetComponent<Rigidbody>();
        Vector3 toPlayer = (player.transform.position - transform.position).normalized;
        objectRB.AddForce(toPlayer * speed);
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float timeElapsed = Time.time - timeStart;
        
        if (transform.position.z < -zLimit)
        {
            Destroy(gameObject);
        }

        if (timeElapsed > TimeLimit)
        {
            Destroy(gameObject);
        }
    }
}
