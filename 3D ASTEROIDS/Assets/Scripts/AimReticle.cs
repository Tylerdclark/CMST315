using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimReticle : MonoBehaviour
{
    public GameObject player;
    public GameManager gameManager;
    private LineRenderer _laserLine;
    private AudioSource _gunAudio;
    private float _nextFire;
    private readonly WaitForSeconds _shotDuration = new WaitForSeconds(0.1f);
    private const float FireRate = 0.75f;
    public GameObject missileGameObject;
    

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (!Physics.Raycast(ray, out var hitData, 1000)) return;
        transform.position = hitData.point;
        if (!hitData.transform.CompareTag("Asteroid") || !(Time.time > _nextFire) || gameManager.isGameOver) return;
        _nextFire = Time.time + FireRate;
        StartCoroutine (ShotEffect());

    }
    private IEnumerator ShotEffect()
    {


        Instantiate(missileGameObject, player.transform.position+new Vector3(0,0,1), player.transform.rotation);
        //Wait for .07 seconds
        yield return _shotDuration;
        
    }
}
