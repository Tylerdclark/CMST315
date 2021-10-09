using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody _objectRb;
    public float speed = 5.0f;
    private const float ZLimit = 10.0f;
    private const float TimeLimit = 12.0f;
    private const float Tumble = 0.5f;
    private float _timeStart;
    public int healthPoints;
    public GameObject explosion;
    
    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _objectRb = GetComponent<Rigidbody>();
        var toPlayer = (_player.transform.position - transform.position).normalized;
        _objectRb.angularVelocity = Random.insideUnitSphere * Tumble;
        _objectRb.AddForce(toPlayer * speed);
        _timeStart = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        var timeElapsed = Time.time - _timeStart;
        
        if (healthPoints <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            var manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            manager.Score(5);
        }

        if (transform.position.z < -ZLimit ||timeElapsed > TimeLimit) //just in case the ship dodges it.
        {
            Destroy(gameObject); //don't give points or make explosion
        }
        
    }

    public void TakeDamage()
    {
        healthPoints -= 1;
    }
}
