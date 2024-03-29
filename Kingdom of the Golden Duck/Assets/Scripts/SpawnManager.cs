using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Array of objects to spawn (note I've removed the private goods variable)
    public GameObject[] coins;

    //Time it takes to spawn theGoodies
    [Space(3)]
    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;

    // the range of X
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    // the range of y
    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;


    void Start()
    {
    }

    public void Update()
    {
        // timer to spawn the next goodie Object
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            SpawnCoins();
            theCountdown = waitingForNextSpawn;
        }
    }


    void SpawnCoins()
    {
        // Defines the min and max ranges for x and y
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

        // Choose a new goods to spawn from the array
        GameObject coinsPrefab = coins[Random.Range(0, coins.Length)];

        // Creates the random object at the random 2D position.
        Instantiate(coinsPrefab, pos, transform.rotation);
    }
}
