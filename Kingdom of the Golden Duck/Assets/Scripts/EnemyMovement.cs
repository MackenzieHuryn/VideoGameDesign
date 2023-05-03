using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float outOfScreenSpeed;
    private Rigidbody2D enemyRb;
    private GameObject player;
    private Vector2 spawnPos;
    private GameManager gameManager; 
    // private bool canFishMove = true;

    // Range of y
    private float yFishMax = -1.54f;
    private float leftBound = -8.38f;
    private float rightBound = 10.02f;
    private float belowBound = -4.15f;

    // Control how many enemies can appear onscreen at a time.
    //private float maxEnemySpawn = 1f;
    public static float fishSpawned = 0f;

    private float timerX; // Timer for the interval
    private float spawnTimeInterval = 100f;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>(); 
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        fishSpawned = 0f;
        timerX = 100f;
        spawnTimeInterval = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
            // Bounds
            if (transform.position.y > yFishMax){
            transform.position = new Vector2(transform.position.x, yFishMax);
            }
            if (transform.position.x < leftBound){
            transform.position = new Vector2(leftBound, transform.position.y);
            }
            if (transform.position.y < belowBound){
            transform.position = new Vector2(transform.position.x, belowBound);
            }

            
            // Movement
            // When the fish is on the screen it moves toward player
            if(transform.position.x <= rightBound ){
                if (timerX>=spawnTimeInterval){
                    fishSpawned++;
                    timerX = 0;
                }
            Vector2 lookDirection = (player.transform.position - transform.position);
            transform.Translate(lookDirection * speed);
            }
            if(transform.position.x <= rightBound){
             // Start timer
            timerX += Time.deltaTime;
             }

            // When the fish is not on the screen it moves with the screen
            if (transform.position.x > rightBound){
            transform.Translate(Vector2.left * Time.deltaTime * outOfScreenSpeed);
            }
    
         
        
        }

    }
    
}
