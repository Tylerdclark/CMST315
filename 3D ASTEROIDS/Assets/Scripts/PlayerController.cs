using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 1.0f;
    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        playerRB.AddForce(Vector3.up * verticalInput * speed);
        playerRB.AddForce(Vector3.right * horizontalInput * speed);

        if (transform.position.x > 10)//This number is likely wrong
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z)
        }//do for negative and y axis
        
    }
}
