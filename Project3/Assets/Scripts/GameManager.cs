using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const float RangeLimit = 8.0f;
    private const float ZValue = 13.0f;
    public GameObject[] asteroidPrefabs;
    public TextMeshPro scoreText;
    private int _score;
    public bool isGameOver;
    public Canvas menuCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        _score = 0;
        Score(0);//set text score
        InvokeRepeating(nameof(SpawnAsteroid), 5,5); //TODO: I will have to use a coroutine to pass health
        //and to change how frequently they spawn //http://answers.unity.com/answers/1391114/view.html
    }

    // Update is called once per frame
    private void Update()
    {
        if (isGameOver)
        {
            CancelInvoke();
            menuCanvas.gameObject.SetActive(true);
        }
        
    }
    private void SpawnAsteroid()//TODO: use a parameter to pass health
    {
        var index = Random.Range(0, asteroidPrefabs.Length);
        var asteroidInstance = Instantiate(asteroidPrefabs[index], GetRandomCoordinates(), transform.rotation);
        asteroidInstance.GetComponent<Asteroid>().healthPoints = 2; //TODO: add the health here
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
    
}
