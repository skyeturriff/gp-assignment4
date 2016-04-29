using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
    AudioSource audioSource;    // Sound to play on Game Over
    //int waveSize;               // The number of enemies spawned for each wave
    float spawnInterval;        // Length of time between waves
    float lastSpawn;            // Time of most recent wave 
    public GameObject enemy;    // Reference to enemy prefab
    public Text scoreText;      // Displays current score to user
    int score;                  // Holds the user's current score
    public Text lifeText;       // Displays current life count
    int lifeCount;              // The current number of lives the snake has

    // Pre-Defined enemy spawn points
    Vector3 spawn1;
    Vector3 spawn2;
    Vector3 spawn3;

    void Start()
    {
        // Spawn enemies at end of flight track, to fly towards player
        spawn1 = new Vector3(-3.0f, 4.0f, 915.0f);
        spawn2 = new Vector3(1.0f, 0.5f, 905.0f);
        spawn3 = new Vector3(5.0f, 3.0f, 910f);

        audioSource = GetComponent<AudioSource>();
        score = 0;
        UpdateScore();
        lifeCount = 3;
        UpdateLives();
        //waveSize = 3;
        spawnInterval = 7.0f;
        SpawnEnemyWave();
        lastSpawn = Time.time;        
    }

    // Check time since last enemy wave spawn
    void Update()
    {
        float timeSinceLastSpawn = Time.time - lastSpawn;
        if (timeSinceLastSpawn > spawnInterval)
        {
            SpawnEnemyWave();
            lastSpawn = Time.time;
        }
    }

    // Spawn a new wave of Enemy objects
    void SpawnEnemyWave()
    {
        GameObject.Instantiate(enemy, spawn1, Quaternion.Euler(Vector3.zero));
        GameObject.Instantiate(enemy, spawn2, Quaternion.Euler(Vector3.zero));
        GameObject.Instantiate(enemy, spawn3, Quaternion.Euler(Vector3.zero));
    }

    // Increment the user's score
    public void AddPoint()
    {
        ++score;
        UpdateScore();

        if (score >= 10)    // Game Over
        {
            StartCoroutine("EndGame");
        }
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
        if (lifeCount == 0) // Game is over
        {
            //SceneManager.LoadScene("MainMenu");
            StartCoroutine("EndGame");
        }
    }

    // Update life count display
    void UpdateLives()
    {
        lifeText.text = "Sheild Health: " + lifeCount.ToString();
    }

    // Load Game Over screen
    IEnumerator EndGame()
    {

        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene("GameOver");
    }
}
