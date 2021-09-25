using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float powerUpStrength = 15.0f;
    public bool hasPowerUp = false;
    private Rigidbody playerRB;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    private void FixedUpdate() //physics should be done in FixedUpdate
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }

    private void Update()
    {
        powerUpIndicator.transform.position = transform.transform.position + new Vector3(0,-0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StopAllCoroutines(); //in case there was another one going
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRB = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = enemyRB.gameObject.transform.position - transform.position;
            
            Debug.Log("Collided with : " + other.gameObject.name + " with power up set to " + hasPowerUp);
            enemyRB.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
}
