using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMovement : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;
    private GameObject fish;
    private GameObject duck;
    public float speed;

    private float leftBound = -8.38f;
    private float rightBound = 10.02f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        
    
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
        fish = FindClosestEnemyFish();
        duck = FindClosestEnemyDuck();

        if(fish.transform.position.x <= rightBound && fish.transform.position.x >= leftBound) {
            if (PaintDuck.playerYPosFish < -0.1181383f ) {
            // If no enemies left, destory projectile
            Vector2 fishDirection = (fish.transform.position - transform.position);
            transform.Translate(fishDirection * speed);
            PaintDuck.playerYPosFish++;
            }
        }
        
        if(duck.transform.position.x <= rightBound && duck.transform.position.x >= leftBound) {
            if (PaintDuck.playerYPosDuck >= -0.1181383 ) {
                Vector2 badDuckDirection = (duck.transform.position - transform.position);
                transform.Translate(badDuckDirection * speed);
                PaintDuck.playerYPosDuck--;
            }
        }
        }
    }

    public GameObject FindClosestEnemyFish()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("EnemyFish");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector2 position = new Vector2 (transform.position.x,transform.position.y);
        foreach (GameObject go in gos)
        {
            Vector2 diff = (Vector2)go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public GameObject FindClosestEnemyDuck()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector2 position = new Vector2 (transform.position.x,transform.position.y);
        foreach (GameObject go in gos)
        {
            Vector2 diff = (Vector2)go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
