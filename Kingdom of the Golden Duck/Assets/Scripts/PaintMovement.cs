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
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        fish1 = GameObject.Find("Enemy Fish(Clone)");
        badDuck = GameObject.Find("EnemyDuck(Clone)");
    
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
        fish1 = GameObject.Find("Enemy Fish(Clone)");
     
        if (player.transform.position.y < -0.1181383f && EnemySpawn.fishSpawned >= 1f) {
            Vector2 fishDirection = (fish1.transform.position - transform.position);
            transform.Translate(fishDirection * speed);
        }

        if(player.transform.position.y >= -0.1181383 && EnemySpawn.badDuckSpawned == 1f) {
            Vector2 badDuckDirection = (badDuck.transform.position - transform.position);
            transform.Translate(badDuckDirection * speed);
        }
        }
    }
}
