using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMovement : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;
    private GameObject fish1;
    private GameObject badDuck;
    public float speed;

    private float leftBound = -8.38f;
    private float rightBound = 10.02f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        fish1 = GameObject.Find("Enemy Fish");
        badDuck = GameObject.Find("EnemyDuck");
    
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
        fish1 = GameObject.Find("Enemy Fish");
        badDuck = GameObject.Find("EnemyDuck");

        if(fish1.transform.position.x <= rightBound && fish1.transform.position.x >= leftBound) {
            if (player.transform.position.y < -0.1181383f && EnemyMovement.fishSpawned >= 1f) {
            Vector2 fishDirection = (fish1.transform.position - transform.position);
            transform.Translate(fishDirection * speed);
            }
        }

        if(badDuck.transform.position.x <= rightBound && badDuck.transform.position.x >= leftBound) {
            if (player.transform.position.y >= -0.1181383 && MoveLeft.badDuckSpawned >= 1f) {
                Vector2 badDuckDirection = (badDuck.transform.position - transform.position);
                transform.Translate(badDuckDirection * speed);
            }
        }
        }
    }
}
