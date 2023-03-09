using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Enemy GameObjects
    public GameObject enemyFishPrefab;
    public GameObject enemyDuckPrefab;

    // Game Manager
    private GameManager gameManager;

    // Floats for randomly spawning enemy
    private float timerX; // Timer for the interval
    private float spawnTimeInterval = 0.5f;

    // Control how many enemies can appear onscreen at a time.
    private float maxEnemySpawn = 2f;
    public static float fishSpawned = 0f;

    // Range of x
    private float xMin = 2f;
    private float xMax = 10f;
  

    // Range of y
    private float yFishMin = -4.55f;
    private float yFishMax = -1.54f;
    

    // Start is called before the first frame update
    void Start()
    {
         gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

         spawnEnemyDucks();

    }

    // Update is called once per frame
    void Update()
    {
        // Start timer
        timerX += Time.deltaTime;
        spawnTimeInterval = Random.Range(1f,10f);

        if (timerX >= spawnTimeInterval && fishSpawned < maxEnemySpawn) {
            spawnFish();
            fishSpawned++;
            // Resets timer back to 0
            timerX = 0;
        }
    }

    void spawnFish() {
        //if (gameManager.isGameActive) {
        // Set random position to spawn to- setting random numbers for x and y
        Vector2 pos = new Vector2 (Random.Range (xMin, xMax), Random.Range (yFishMin, yFishMax));
        // Creates object at random position
        Instantiate(enemyFishPrefab, pos, enemyFishPrefab.transform.rotation); 
       // } 
    }

    void spawnEnemyDucks() {
    Vector2 pos = new Vector2 ( (xMax + 2f ), 0);
    Instantiate(enemyDuckPrefab, pos, enemyDuckPrefab.transform.rotation); 
    }
}

