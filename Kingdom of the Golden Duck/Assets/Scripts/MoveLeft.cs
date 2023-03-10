using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 2;
    private GameManager gameManager;
    
    void Start() {
         gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    
    }


    // Update is called once per frame
    void Update()
    {
         //if (gameManager.isGameActive) {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
         //}
    }
}
