using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    private float _timeStart;
    private const float TimeLimit = 3.0f;
    private AudioSource _thudSound;
    // Start is called before the first frame update
    private void Start()
    {
        _thudSound = GetComponent<AudioSource>();
        _thudSound.Play();
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
