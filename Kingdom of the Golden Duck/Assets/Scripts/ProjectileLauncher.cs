using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameManager gameManager;

    // Floats for preventing space spam
    private float spawnTimeInterval = 1f; // Interval between projectile spawns
    private float timerX; // Timer for the interval


    // Start is called before the first frame updat e
    void Start()
    {
         // For the first spawn, timer is 0.5 which means we can spawn a projectile
        timerX = spawnTimeInterval;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // This starts the timer
        timerX += Time.deltaTime;

        if (gameManager.isGameActive) {
            // Project projectile when W pressed
            if(GameManager.regDuck == true && timerX >= spawnTimeInterval) {
                if (Input.GetKeyDown(KeyCode.W)) {
                Vector2 playerPosition = transform.position;
                Instantiate(projectilePrefab, playerPosition, projectilePrefab.transform.rotation);
                timerX = 0;
                    //Play Audio
                    //playerAudio.PlayOneShot(projectileSound, 0.5f);
                }
            }
        }
    }
}
