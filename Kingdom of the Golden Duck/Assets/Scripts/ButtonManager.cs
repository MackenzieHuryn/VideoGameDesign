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
    public GameObject paintBar;
    private SpriteRenderer sprPaint;
    public GameObject unicornBar;
    private SpriteRenderer sprUni;
    public GameObject scubaBar;
    private SpriteRenderer sprScuba;

    void Start(){
        sprPaint = paintBar.GetComponent<SpriteRenderer>();
        sprPaint.drawMode = SpriteDrawMode.Sliced;
        sprPaint.size = new Vector2(0f, 1.0f);
        sprUni = unicornBar.GetComponent<SpriteRenderer>();
        sprUni.drawMode = SpriteDrawMode.Sliced;
        sprUni.size = new Vector2(0f, 1.0f);
        sprScuba = scubaBar.GetComponent<SpriteRenderer>();
        sprScuba.drawMode = SpriteDrawMode.Sliced;
        sprScuba.size = new Vector2(0f, 1.0f);
    }
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
                sprUni.size = new Vector2(timeLeft/20.0f, 1.0f);
                } else{
                    UB = true;
                    sprUni.size = new Vector2(0f, 1.0f);
                }
            }  
        if(!PDB){
            
            if(timeLeft > 0){
                timeLeft = timeLeft - Time.deltaTime;
                sprPaint.size = new Vector2(timeLeft/20.0f, 1.0f);
                } else{
                    PDB = true;
                    sprPaint.size = new Vector2(0f, 1.0f);
                }
        } 
        if(!SDB){
            
            if(timeLeft > 0){
                timeLeft = timeLeft - Time.deltaTime;
                sprScuba.size = new Vector2(timeLeft/20.0f, 1.0f);
                } else{
                    SDB = true;
                    sprScuba.size = new Vector2(0f, 1.0f);
                }
        }    
    }

    public void UnicornActivation()
    {
            coinCounterScript.DecreaseCoins(5);
            timeLeft = 20;
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
        timeLeft = 20;
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
        timeLeft = 20;
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