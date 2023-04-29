using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 2;
    private GameManager gameManager;
    public static float badDuckSpawned = 0f;
    private float rightBound = 10.02f;
    
    void Start() {
         gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
          badDuckSpawned = 0f;
    }
     

    // Update is called once per frame
    void Update()
    {
         if (gameManager.isGameActive) {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (gameObject.tag == "Enemy") {
          if(transform.position.x <= rightBound){
            badDuckSpawned++;
            }
        }
         }
    }
}
