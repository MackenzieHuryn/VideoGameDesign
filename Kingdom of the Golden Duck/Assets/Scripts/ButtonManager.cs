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

    public void UnicornActivation()
    {
        if (coinCounterScript.currentCoins - 5 >= 0)
        {
            UnicornButton.SetActive(false);
            coinCounterScript.currentCoins -= 5;
            coinCounterScript.coinText.text = "Coins: " + coinCounterScript.currentCoins.ToString();
            StartCoroutine(WaitForUButton());
        }
    }

    public void PaintDuckActivation()
    {
        if (coinCounterScript.currentCoins - 5 >= 0)
        {
            PaintDuckButton.SetActive(false);
            coinCounterScript.currentCoins -= 5;
            coinCounterScript.coinText.text = "Coins: " + coinCounterScript.currentCoins.ToString();
            StartCoroutine(WaitForPButton());
        }
    }

    public void ScubaDuckActivation()
    {
        if (coinCounterScript.currentCoins - 5 >= 0)
        {
            ScubaDuckButton.SetActive(false);
            coinCounterScript.currentCoins -= 5;
            coinCounterScript.coinText.text = "Coins: " + coinCounterScript.currentCoins.ToString();
            StartCoroutine(WaitForSButton());
        }
    }

    IEnumerator WaitForUButton()
    {
        yield return new WaitForSeconds(15);
        UnicornButton.SetActive(true);
    }

    IEnumerator WaitForPButton()
    {
        yield return new WaitForSeconds(15);
        PaintDuckButton.SetActive(true);
    }

    IEnumerator WaitForSButton()
    {
        yield return new WaitForSeconds(15);
        ScubaDuckButton.SetActive(true);
    }
}