using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class ButtonManager : MonoBehaviour
{
    public CoinCounter coinCounterScript;
    public GameObject UnicornButton;
    public GameObject PaintDuckButton;
    public GameObject ScubaDuckButton;
    public bool UB = true;
    public bool PDB = true;
    public bool SDB = true;
    public float timeLeft;

    private void Update()
    {
        if (coinCounterScript.currentCoins < 5)
        {
            UnicornButton.SetActive(false);
            PaintDuckButton.SetActive(false);
            ScubaDuckButton.SetActive(false);
        }
        else if (coinCounterScript.currentCoins > 4)
        {
            UnicornButton.SetActive(UB);
            PaintDuckButton.SetActive(PDB);
            ScubaDuckButton.SetActive(SDB);
        }
        if(!UB){
            
            if(timeLeft > 0){
                timeLeft = timeLeft - Time.deltaTime;
                } else{
                    UB = true;
                }
            }  
        if(!PDB){
            
            if(timeLeft > 0){
                timeLeft = timeLeft - Time.deltaTime;
                } else{
                    PDB = true;
                }
        } 
        if(!SDB){
            
            if(timeLeft > 0){
                timeLeft = timeLeft - Time.deltaTime;
                } else{
                    SDB = true;
                }
        }    
    }

    public void UnicornActivation()
    {
            coinCounterScript.DecreaseCoins(5);
            timeLeft = 5;
            UB = false;
            //UnicornButton.SetActive(false);
            //coinCounterScript.currentCoins -= 5;
            //coinCounterScript.coinText.text = "Coins: " + coinCounterScript.currentCoins.ToString();
            //StartCoroutine(WaitForUButton());
        //}
    }

    public void PaintDuckActivation()
    {
        coinCounterScript.DecreaseCoins(5);
        timeLeft = 5;
        PDB = false;
        //if (coinCounterScript.currentCoins > 4)
        //{
            //PaintDuckButton.SetActive(false);
            //coinCounterScript.currentCoins -= 5;
            //coinCounterScript.coinText.text = "Coins: " + coinCounterScript.currentCoins.ToString();
            //StartCoroutine(WaitForPButton());
        //}
    }

    public void ScubaDuckActivation()
    {
        coinCounterScript.DecreaseCoins(5);
        timeLeft = 5;
        SDB = false;
        //if (coinCounterScript.currentCoins > 4)
        //{
            //ScubaDuckButton.SetActive(false);
            //coinCounterScript.currentCoins -= 5;
            //coinCounterScript.coinText.text = "Coins: " + coinCounterScript.currentCoins.ToString();
            //StartCoroutine(WaitForSButton());
        //}
    }


}