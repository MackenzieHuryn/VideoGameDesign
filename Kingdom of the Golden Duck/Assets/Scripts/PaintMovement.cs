using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMovement : MonoBehaviour
{
    private GameObject fish1;
    private GameObject badDuck;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        fish1 = GameObject.Find("Enemy Fish(Clone)");
        badDuck = GameObject.Find("EnemyDuck(Clone)");
    
    }

    // Update is called once per frame
    void Update()
    {
        fish1 = GameObject.Find("Enemy Fish(Clone)");
        Vector2 fishDirection = (fish1.transform.position - transform.position);

         transform.Translate(fishDirection * speed);
    }
}
