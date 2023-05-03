using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 2;
    private GameManager gameManager;
    public static float badDuckSpawned = 0f;
    private float rightBound = 10.02f;
    
    private float timerX; // Timer for the interval
    private float spawnTimeInterval = 100f;

    void Start() {
         gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
          badDuckSpawned = 0f;
          timerX = 100f;
          spawnTimeInterval = 100f;
    }
     

    // Update is called once per frame
    void Update()
    {
         if (gameManager.isGameActive) {
        transform.Translate(Vector2.left * Time.deltaTime * speed);


        if (gameObject.tag == "Enemy" && timerX>=spawnTimeInterval) {
          if(transform.position.x <= rightBound){
            badDuckSpawned++;
            timerX = 0;
            }
        }
        if(transform.position.x <= rightBound){
           // Start timer
        timerX += Time.deltaTime;
        }
         }
    }
}
