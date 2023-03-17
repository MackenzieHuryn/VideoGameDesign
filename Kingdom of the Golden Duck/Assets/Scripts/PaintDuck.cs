using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDuck : MonoBehaviour
{
    

    public GameObject paintPrefab;
    private GameManager gameManager;
    private GameObject player;

    // Floats for preventing space spam
    private float spawnTimeInterval = 1f; // Interval between projectile spawns
    private float timerX; // Timer for the interval


    // Start is called before the first frame update
    void Start()
    {
        // For the first spawn, timer is 0.5 which means we can spawn a projectile
        timerX = spawnTimeInterval;

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // This starts the timer
        timerX += Time.deltaTime;

        if(GameManager.artDuck) {
            if(EnemySpawn.fishSpawned >= 1f && timerX >= spawnTimeInterval && player.transform.position.y < -0.1181383f) {
                // Project projectile when W pressed
                if (Input.GetKeyDown(KeyCode.W)) {
                    Vector2 playerPosition = transform.position;
                    Instantiate(paintPrefab, playerPosition, paintPrefab.transform.rotation);
                    timerX = 0;
                }
             }

             if(EnemySpawn.badDuckSpawned == 1f && timerX >= spawnTimeInterval && player.transform.position.y >= -0.1181383f ) {
                // Project projectile when W pressed
                if (Input.GetKeyDown(KeyCode.W)) {
                    Vector2 playerPosition = transform.position;
                    Instantiate(paintPrefab, playerPosition, paintPrefab.transform.rotation);
                    timerX = 0;
                }
             } 
        
        }
    }
    
}
