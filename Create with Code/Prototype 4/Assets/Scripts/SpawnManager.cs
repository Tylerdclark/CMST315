using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        GeneratePowerUp();
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnXPos = Random.Range(-spawnRange, spawnRange);
        float spawnZPos = Random.Range(-spawnRange, spawnRange);
         
        return new Vector3(spawnXPos, 0, spawnZPos); 
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            GeneratePowerUp();
        }
    }

    private void GeneratePowerUp()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPos(), transform.rotation);
    }

    void SpawnEnemyWave(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
