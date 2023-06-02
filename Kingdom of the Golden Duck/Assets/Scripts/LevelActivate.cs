using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelActivate : MonoBehaviour
{

    public GameObject GoldenDuck1;
    public GameObject GreyDuck1;

    public GameObject BlockedDuck2;
    public GameObject GreyDuck2;
    public GameObject GoldenDuck2;

    public GameObject BlockedDuck3;
    public GameObject GreyDuck3;
    public GameObject GoldenDuck3;

    public GameObject BlockedDuck4;
    public GameObject GreyDuck4;
    public GameObject GoldenDuck4;

    public GameObject BlockedDuck5;
    public GameObject GreyDuck5;
    public GameObject GoldenDuck5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GoldenDuckCollection.L1Duck > 0)
        {
            GoldenDuck1.SetActive(true);
            BlockedDuck2.SetActive(false);
            GreyDuck2.SetActive(true);
        }

        if (GoldenDuckCollection.L2Duck > 0)
        {
            GoldenDuck2.SetActive(true);
            BlockedDuck3.SetActive(false);
            GreyDuck3.SetActive(true);
            Debug.Log("golden 2. grey 3");
        }

        if (GoldenDuckCollection.L3Duck > 0)
        {
            GoldenDuck3.SetActive(true);
            BlockedDuck4.SetActive(false);
            GreyDuck4.SetActive(true);
        }

        if (GoldenDuckCollection.L4Duck > 0)
        {
            GoldenDuck4.SetActive(true);
            BlockedDuck5.SetActive(false);
            GreyDuck5.SetActive(true);
        }

        if (GoldenDuckCollection.L5Duck > 0)
        {
            GoldenDuck5.SetActive(true);
        }
    }

    
}
