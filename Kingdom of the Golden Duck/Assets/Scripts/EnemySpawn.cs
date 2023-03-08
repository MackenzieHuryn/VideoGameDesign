using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Enemy GameObjects
    public GameObject enemyPrefab;

    // Game Manager
    private GameManager gameManager;

    // Floats for randomly spawning enemy
    private float timerX; // Timer for the interval
    private float spawnTimeInterval = 0.5f;

    // Control how many enemies can appear onscreen at a time.
    private float maxEnemySpawn = 2f;
    public static float enemiesSpawned = 0f;

    // Range of x
    private float xMin = 2f;
    private float xMax = 10f;
  

    // Range of y
    private float yMin = 0f;
    private float yMax = 4.38f;
    

    // Start is called before the first frame update
    void Start()
    {
         gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Start timer
        timerX += Time.deltaTime;
        spawnTimeInterval = Random.Range(1f,10f);

        if (timerX >= spawnTimeInterval && enemiesSpawned <= maxEnemySpawn) {
            spawnBat();
            enemiesSpawned++;
            // Resets timer back to 0
            timerX = 0;
        }
    }

    void spawnBat() {
        //if (gameManager.isGameActive) {
        // Set random position to spawn to- setting random numbers for x and y
        Vector2 pos = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
        // Creates object at random position
        Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation); 
       // } 
    }
}

