using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // private GameManager gameManager;
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
       // gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(gameManager.isGameActive) {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        //}
    }
}