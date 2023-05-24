using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldenDuckCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
            {
                GoldenDuckCollection.L1Duck++;
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
            {
                GoldenDuckCollection.L2Duck++;
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level3"))
            {
                GoldenDuckCollection.L3Duck++;
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level4"))
            {
                GoldenDuckCollection.L4Duck++;
            }

        }

    }
}
