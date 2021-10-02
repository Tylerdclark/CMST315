using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const float RangeLimit = 8.0f;
    private const float ZValue = 13.0f;
    public GameObject[] asteroidPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 5,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAsteroid()
    {
        int index = Random.Range(0, asteroidPrefabs.Length);
        Instantiate(asteroidPrefabs[index], getRandomCoordinates(), transform.rotation);
    }

    Vector3 getRandomCoordinates()
    {
        float x = Random.Range(-RangeLimit, RangeLimit);
        float y = Random.Range(-RangeLimit, RangeLimit);
        return new Vector3(x, y,ZValue);
    }
    
}
