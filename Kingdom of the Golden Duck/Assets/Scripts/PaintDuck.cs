using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDuck : MonoBehaviour
{
    

    public GameObject paintPrefab;
    private GameManager gameManager;
    private GameObject player;
    public AudioClip paintSound;
    private AudioSource paintAudio;

    // Floats for preventing space spam
    private float spawnTimeInterval = 0.12f; // Interval between projectile spawns
    private float timerX; // Timer for the interval
    
    public static float playerYPosFish;
    public static float playerYPosDuck;


    // Start is called before the first frame update
    void Start()
    {
        // For the first spawn, timer is 0.5 which means we can spawn a projectile
        timerX = spawnTimeInterval;

        player = GameObject.Find("Player");

        // PaintAudio
        paintAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // This starts the timer
        timerX += Time.deltaTime;

        if(GameManager.artDuck) {
            if(EnemyMovement.fishSpawned >= 1f && timerX >= spawnTimeInterval && player.transform.position.y < -0.1181383f) {
                playerYPosFish = player.transform.position.y;
                // Project projectile when W pressed
                if (Input.GetKeyDown(KeyCode.W)) {
                    Vector2 playerPosition = transform.position;
                    Instantiate(paintPrefab, playerPosition, paintPrefab.transform.rotation);
                    timerX = 0;
                    //Play Audio
                paintAudio.PlayOneShot(paintSound, 0.5f);
                }
             }

             if(MoveLeft.badDuckSpawned >= 1f && timerX >= spawnTimeInterval && player.transform.position.y >= -0.1181383f ) {
                playerYPosDuck = player.transform.position.y;
                // Project projectile when W pressed
                if (Input.GetKeyDown(KeyCode.W)) {
                    Vector2 playerPosition = transform.position;
                    Instantiate(paintPrefab, playerPosition, paintPrefab.transform.rotation);
                    timerX = 0;
                    paintAudio.PlayOneShot(paintSound, 0.5f);
                }
             } 
        
        }
    }
    
}
