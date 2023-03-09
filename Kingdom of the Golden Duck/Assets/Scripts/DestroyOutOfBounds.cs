using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float rightBound = 10f;
    // private float leftBound = -10f;

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.x > rightBound) {
            Destroy(gameObject);    
        }
    }
}
