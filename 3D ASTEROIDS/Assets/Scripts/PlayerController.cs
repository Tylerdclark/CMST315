using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 1.5f;
    public GameObject projectilePrefab;
    private const float VerticalBound = 1.5f;
    private const float HorizontalBound = 3.0f;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var transform1 = transform;
            Instantiate(projectilePrefab, transform1.position+new Vector3(0,0,0.5f), transform1.rotation);
        }
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        
        BoundPlayer();
    }

    private void BoundPlayer()
    {
        var position = transform.position;

        if (transform.position.x > HorizontalBound)
        {
            position = new Vector3(HorizontalBound, position.y, position.z);
            transform.position = position;
        }

        if (transform.position.x < -HorizontalBound)
        {
            position = new Vector3(-HorizontalBound, position.y, position.z);
            transform.position = position;
        }

        if (transform.position.y > VerticalBound)
        {
            position = new Vector3(position.x, VerticalBound, position.z);
            transform.position = position;
        }

        if (transform.position.y < 0)
        {
            position = new Vector3(position.x, 0, position.z);
            transform.position = position;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Game over!");
        }
    }
}
