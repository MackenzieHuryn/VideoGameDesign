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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GoldenDuckCollection.L1Duck > 0)
        {
            GreyDuck1.SetActive(false);
            GoldenDuck1.SetActive(true);
            BlockedDuck2.SetActive(false);
            GreyDuck2.SetActive(true);
        }

        if (GoldenDuckCollection.L2Duck > 0)
        {
            GreyDuck2.SetActive(false);
            GoldenDuck2.SetActive(true);
            BlockedDuck3.SetActive(false);
            GreyDuck3.SetActive(true);
        }

        if (GoldenDuckCollection.L3Duck > 0)
        {
            GreyDuck3.SetActive(false);
            GoldenDuck3.SetActive(true);
            BlockedDuck4.SetActive(false);
            GreyDuck4.SetActive(true);
        }

        if (GoldenDuckCollection.L4Duck > 0)
        {
            GreyDuck4.SetActive(false);
            GoldenDuck4.SetActive(true);
        }
    }

    
}
