using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 spawnPos;
    public float yPos;
    public float repeatPos;
    public float xPosition;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Establish default starting position 
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        spawnPos = new Vector2( xPosition, yPos );  
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
        // If background moves left by its repeat width, move it back to start position
        if (transform.position.x < repeatPos) {
            transform.position = spawnPos;
        }
        }
    }
}
