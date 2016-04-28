using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
    int waveSize;               // The number of enemies spawned for each wave
    float spawnInterval;        // Length of time between waves
    float lastSpawn;            // Time of most recent wave 
    //public GameObject enemy;    // Reference to enemy prefab
    public Text scoreText;      // Displays current score to user
    int score;                  // Holds the user's current score
    public Text lifeText;       // Displays current life count
    int lifeCount;              // The current number of lives the snake has

    void Start()
    {
        score = 0;
        UpdateScore();
        lifeCount = 3;
        UpdateLives();
        waveSize = 5;
        spawnInterval = 7.0f;
        //SpawnEnemyWave();
        lastSpawn = Time.time;
    }

    // Increment the user's score
    public void AddPoint()
    {
        Debug.Log("Point Added!");
        ++score;
        UpdateScore();
    }

    // Update score display
    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Decriment user's lives
    public void RemoveLife()
    {
        if (lifeCount > 0)
        {
            --lifeCount;
            UpdateLives();
        }
        if (lifeCount == 0) // Game is over, restart level
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Update life count display
    void UpdateLives()
    {
        lifeText.text = "Lives: " + lifeCount.ToString();
    }
}
