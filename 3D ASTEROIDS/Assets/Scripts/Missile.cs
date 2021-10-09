using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private GameObject _reticle;
    private const float Speed = 500.0f;
    private Rigidbody _rigidbody;
    private const float TimeLimit = 5.0f;
    private float _timeStart;
    public GameObject explosion;
    private AudioSource _launchSound;
    // Start is called before the first frame update
    private void Start()
    {
        _launchSound = GetComponent<AudioSource>();
        _launchSound.Play();
        _timeStart = Time.time;
        _reticle = GameObject.FindWithTag("Reticle");
        _rigidbody = GetComponent<Rigidbody>();
        var shootVec = (_reticle.transform.position - transform.position).normalized;
        _rigidbody.AddForce(shootVec * Speed);
    }

    // Update is called once per frame
    private void Update()
    {
        var timeElapsed = Time.time - _timeStart;
        if (timeElapsed > TimeLimit)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.transform.CompareTag("Asteroid")) return;
        var asteroid = other.gameObject.transform.GetComponent<Asteroid>();
        Instantiate(explosion, (other.ClosestPointOnBounds(transform.position)), Quaternion.identity);
        asteroid.TakeDamage();
        Destroy(gameObject);
    }
}
