using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //private float rightBound = 10f;
    private float leftBound = -10f;
    private float rightBound = 10f;
    private float upBound = 6f;

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.x < leftBound) {
            Destroy(gameObject);
            if(gameObject.tag == "Enemy") {
                MoveLeft.badDuckSpawned--;
            }    
        }

        if (transform.position.x > rightBound) {
            if(gameObject.tag == "shoot") {
                Destroy(gameObject);
            }
        }

        if (GameManager.artDuck == true) {
            if (transform.position.y > upBound){
                Destroy(gameObject);
            }
        }
    }
}
