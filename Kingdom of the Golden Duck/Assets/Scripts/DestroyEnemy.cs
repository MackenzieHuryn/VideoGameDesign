using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    //runs this code when the projectile collides with an enemy
    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Enemy" ){ 
            // Let the enemy spawn script know it can spawn another enemy
            if (collision.gameObject.tag == "Enemy"){
            EnemySpawn.fishSpawned--;
            }
            // Destroys object it collides with
            Destroy(collision.gameObject);
            // Destroys projectile
            Destroy(gameObject);
        }
        
    }
}
