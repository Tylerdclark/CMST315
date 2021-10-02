using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimReticle : MonoBehaviour
{
    public GameObject player;
    private LineRenderer _laserLine;
    private AudioSource _gunAudio;
    private float _nextFire;
    private readonly WaitForSeconds _shotDuration = new WaitForSeconds(0.1f);
    public float fireRate = 0.25f;
    

    // Start is called before the first frame update
    private void Start()
    {
        _laserLine = GetComponent<LineRenderer>();
        //_gunAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (!Physics.Raycast(ray, out var hitData, 1000)) return;
        transform.position = hitData.point;
        if (!hitData.transform.CompareTag("Asteroid") || !(Time.time > _nextFire)) return;
        _nextFire = Time.time + fireRate;
        // Start our ShotEffect coroutine to turn our laser line on and off
        StartCoroutine (ShotEffect());
        // Set the start position for our visual effect for our laser to the position of gunEnd
        _laserLine.SetPosition (0, player.gameObject.transform.position);
        // Set the end position for our laser line 
        _laserLine.SetPosition (1, hitData.point);
                
                
        var asteroid = hitData.transform.GetComponent<Asteroid>();
        asteroid.TakeDamage();

    }
    private IEnumerator ShotEffect()
    {
        // Play the shooting sound effect
        //gunAudio.Play ();

        // Turn on our line renderer
        _laserLine.enabled = true;

        //Wait for .07 seconds
        yield return _shotDuration;

        // Deactivate our line renderer after waiting
        _laserLine.enabled = false;
    }
}
