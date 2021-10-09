using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private const float RangeLimit = 8.0f;
    private const float ZValue = 13.0f;
    private const int Difficulty = 12; //every specified seconds, add another asteroid
    
    private int _score;
    private float _timeStart;
    private float _timeElapsed;
    private int _asteroidCount;
    private float _timeDelay;
    private int _asteroidHealth;
    
    public GameObject[] asteroidPrefabs;
    public TextMeshPro scoreText;
    public bool isGameOver;
    public Canvas menuCanvas;
    

    // Start is called before the first frame update
    private void Start()
    {
        _timeStart = Time.time;
        _asteroidCount = 1;
        _asteroidHealth = 1;
        _timeDelay = 5.0f;
        _score = 0;
        Score(0);//set text score
        StartCoroutine(TimedSpawnAsteroid());
        //and to change how frequently they spawn //http://answers.unity.com/answers/1391114/view.html
    }

    // Update is called once per frame
    private void Update()
    {
        _timeElapsed = Time.time - _timeStart;
        if (!isGameOver) return;
        menuCanvas.gameObject.SetActive(true);

    }
    private void SpawnAsteroid(int health)
    {
        var index = Random.Range(0, asteroidPrefabs.Length);
        var asteroidInstance = Instantiate(asteroidPrefabs[index], GetRandomCoordinates(), transform.rotation);
        asteroidInstance.GetComponent<Asteroid>().healthPoints = health; 
    }

    private static Vector3 GetRandomCoordinates()
    {
        var x = Random.Range(-RangeLimit, RangeLimit);
        var y = Random.Range(-RangeLimit, RangeLimit);
        return new Vector3(x, y,ZValue);
    }

    public void Score(int amount)
    {
        _score += amount;
        scoreText.text = "Score: " + _score;
    }

    private IEnumerator TimedSpawnAsteroid()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(_timeDelay);
            for (var i = 0; i < _asteroidCount; i++)
            {
                SpawnAsteroid(_asteroidHealth);
            }
            CheckForUpgrade();
            
        }
    }

    private IEnumerator ShowErrorMessage(string message)
    {
        
        yield return new WaitForSeconds(2);
    }

    private void CheckForUpgrade()
    {
        if ((int)_timeElapsed % Difficulty == 0 && _timeElapsed > Difficulty)
        {
            Debug.Log("Upgrade count && delay");
            
            _asteroidCount++;
            if (_timeDelay > 0)
            {
                
                _timeDelay -= 0.2f;
            }
            else
            {
                _timeDelay = 0;
            }
            

        }

        const int healthDifficulty = Difficulty * 2;

        if ((int)_timeElapsed % healthDifficulty != 0 || !(_timeElapsed > healthDifficulty)) return;
        Debug.Log("Upgrade health");
        _asteroidHealth++;
    }
    
    
}
