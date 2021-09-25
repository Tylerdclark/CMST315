using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroidPrefab;
    private const float RangeLimit = 5.0f;
    private const float ZValue = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 5,5);
        //Invoke(nameof(SpawnAsteroid),5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAsteroid()
    {
        Instantiate(asteroidPrefab, getRandomCoordinates(), transform.rotation);
    }

    Vector3 getRandomCoordinates()
    {
        float x = Random.Range(-RangeLimit, RangeLimit);
        float y = Random.Range(-RangeLimit, RangeLimit);
        return new Vector3(x, y,ZValue);
    }
    
}
