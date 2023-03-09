using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject coinPrefab;
    private Vector3 spawnPos1 = new Vector3(0, -3, 0);
    private Vector3 spawnPos2 = new Vector3(6, 3, 0);

    private float startDelay = 5;
    private float repeatRate = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoin", startDelay, repeatRate);
    }

    void SpawnCoin()
    {
        Instantiate(coinPrefab, spawnPos1, coinPrefab.transform.rotation);
        Instantiate(coinPrefab, spawnPos2, coinPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
