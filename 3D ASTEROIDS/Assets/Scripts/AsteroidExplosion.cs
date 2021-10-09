using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplosion : MonoBehaviour
{
    private float _timeStart;
    private const float TimeLimit = 3.0f;
    private AudioSource _explosionSound;
    // Start is called before the first frame update
    private void Start()
    {
        _explosionSound = GetComponent<AudioSource>();
        _explosionSound.Play();
        _timeStart = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time - _timeStart> TimeLimit)
        {
            Destroy(gameObject);
        }
    }
}
