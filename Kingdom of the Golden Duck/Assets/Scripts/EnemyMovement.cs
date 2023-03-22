using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D enemyRb;
    private GameObject player;
    private Vector2 spawnPos;
    private GameManager gameManager; 
    // private bool canFishMove = true;

    // Range of y
    private float yFishMax = -1.54f;
    private float leftBound = -8.38f;
    private float rightBound = 8.68f;
    private float belowBound = -4.15f;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>(); 
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
            if (transform.position.y > yFishMax){
            transform.position = new Vector2(transform.position.x, yFishMax);
            }
            if (transform.position.x > rightBound){
            transform.position = new Vector2(rightBound, transform.position.y);
            }
            if (transform.position.x < leftBound){
            transform.position = new Vector2(leftBound, transform.position.y);
            }
            if (transform.position.y < belowBound){
            transform.position = new Vector2(transform.position.x, belowBound);
            }
            

            Vector2 lookDirection = (player.transform.position - transform.position);
            //enemyRb.AddForce(lookDirection * speed);
            transform.Translate(lookDirection * speed);
         
        
        }

    }
    
}
