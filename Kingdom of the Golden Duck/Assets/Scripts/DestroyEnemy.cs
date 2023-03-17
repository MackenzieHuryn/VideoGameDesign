using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    //runs this code when the projectile collides with an enemy
    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "EnemyFish") { 
            
            // Destroys object it collides with
            Destroy(collision.gameObject);
            EnemySpawn.fishSpawned--;
            // Destroys projectile
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy") {
             // Destroys object it collides with
            Destroy(collision.gameObject);
            EnemySpawn.badDuckSpawned--;
            // Destroys projectile
            Destroy(gameObject);
            
        }
        
    }
}
