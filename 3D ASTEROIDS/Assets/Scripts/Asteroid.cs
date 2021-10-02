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
        
        if (transform.position.z < -ZLimit || timeElapsed > TimeLimit || healthPoints <= 0)
        {
            Destroy(gameObject);
            var manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            manager.Score(5); //TODO: create some scoring that makes sense
        }

        if (timeElapsed > TimeLimit) //just in case the ship dodges it.
        {
            Destroy(gameObject);
        }
        
    }

    public void TakeDamage()
    {
        healthPoints -= 1;
        Debug.Log("Health = " +  healthPoints);
    }
}
