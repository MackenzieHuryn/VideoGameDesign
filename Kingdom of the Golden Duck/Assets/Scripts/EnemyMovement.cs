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
    // private float yFishMax = -1.54f;
    
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
        //if (gameManager.isGameActive) {
        
            Vector2 lookDirection = (player.transform.position - transform.position);
            //enemyRb.AddForce(lookDirection * speed);
            transform.Translate(lookDirection * speed);
         
        
     //   }

    }
    
}
