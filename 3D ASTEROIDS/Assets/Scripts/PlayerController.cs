using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float Speed = 1.5f;
    public GameObject reticlePrefab;
    public GameManager gameManager;
    private const float YBound = 1.25f;
    private const float XBound = 1.25f;
    private const float ZBound = 1.25f;
    
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameManager.isGameOver) return;
        MovePlayer();
        transform.LookAt(reticlePrefab.transform);
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * verticalInput * Speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * Speed * Time.deltaTime);
        
        BoundPlayer();
    }

    private void BoundPlayer()
    {
        var position = transform.position;
        if (transform.position.x > XBound)
        {
            position = new Vector3(XBound, position.y, position.z);
            transform.position = position;
        }
        if (transform.position.x < -XBound)
        {
            position = new Vector3(-XBound, position.y, position.z);
            transform.position = position;
        }
        if (transform.position.y > YBound)
        {
            position = new Vector3(position.x, YBound, position.z);
            transform.position = position;
        }
        if (transform.position.y < 0)
        {
            position = new Vector3(position.x, 0, position.z);
            transform.position = position;
        }
        if (transform.position.z > ZBound || transform.position.z < ZBound )
        {
            position = new Vector3(position.x, position.y, ZBound);
            transform.position = position;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.CompareTag("Asteroid"))
        {
            gameManager.isGameOver = true;
        }
    }

}
