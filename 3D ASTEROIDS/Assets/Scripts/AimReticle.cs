using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimReticle : MonoBehaviour
{
    public GameObject player;
    private LineRenderer laserLine;
    private AudioSource gunAudio;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    // WaitForSeconds object used by our ShotEffect 

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        
        RaycastHit hitData;
        if(Physics.Raycast(ray, out hitData, 1000))
        {
            transform.position = hitData.point;
            if (hitData.transform.CompareTag("Asteroid"))
            {
                // Start our ShotEffect coroutine to turn our laser line on and off
                StartCoroutine (ShotEffect());
                // Set the start position for our visual effect for our laser to the position of gunEnd
                laserLine.SetPosition (0, player.gameObject.transform.position);
                // Set the end position for our laser line 
                laserLine.SetPosition (1, hitData.point);
                
                
                Destroy(hitData.collider.gameObject);
                
            }
        }
        
    }
    private IEnumerator ShotEffect()
    {
        // Play the shooting sound effect
        //gunAudio.Play ();

        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}
