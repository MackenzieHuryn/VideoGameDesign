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
    public bool startScrolling = false;

    // Start is called before the first frame update
    void Start()
    {
            
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    
            
         
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.startS && !startScrolling){
            startPos = transform.position; // Establish default starting position 
            spawnPos = new Vector2( xPosition, yPos ); 
            startScrolling = true;
        }
        if (startScrolling) {
        // If background moves left by its repeat width, move it back to start position
            if (transform.position.x < repeatPos) {
                transform.position = spawnPos;
            }
        }
    }
}
