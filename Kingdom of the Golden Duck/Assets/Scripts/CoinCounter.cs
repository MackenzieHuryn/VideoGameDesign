
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounter : MonoBehaviour
{
   public static CoinCounter instance;

    public TMP_Text coinText;
    public int currentCoins = 0;

    // Audio clip variables
    public AudioClip coinSound;
    private AudioSource coinAudio;

    void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "       : " + currentCoins.ToString();
        // Player Audio
        coinAudio = GetComponent<AudioSource>();
    }

    public void IncreaseCoins(int v)
    {
        //Play Audio
            coinAudio.PlayOneShot(coinSound, 0.5f);
        currentCoins += v;
        coinText.text = "       : " + currentCoins.ToString();
    }

    // Update is called once per frame
    public void DecreaseCoins(int v)
    {
        currentCoins -= v;
        coinText.text = "       : " + currentCoins.ToString();
    }
}
