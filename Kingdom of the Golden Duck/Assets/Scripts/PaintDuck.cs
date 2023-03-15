using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDuck : MonoBehaviour
{
    

    public GameObject paintPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.artDuck) {
            if(EnemySpawn.fishSpawned >= 1f) {
                // Project projectile when W pressed
                if (Input.GetKeyDown(KeyCode.W)) {
                    Vector2 playerPosition = transform.position;
                    Instantiate(paintPrefab, playerPosition, paintPrefab.transform.rotation);
                    
                }
             } 
        
        }
    }
    
}
