using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray; // Holds possible costumes for player
    private GameManager gameManager;
    public ButtonManager buttonManager;
    public CoinCounter coinCounter;
    void Awake(){
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GameManager.regDuck = true;
    }
    
    void Update() {
        if (Input.GetKeyDown (KeyCode.Alpha1) && buttonManager.UB && coinCounter.currentCoins >= 5) {  
            Debug.Log("1-unicorn");
            GameManager.regDuck = false;
            GameManager.artDuck = false;
            GameManager.scubDuck = false;
            GameManager.uniDuck = true;
            ChangeSprite(0);
            Debug.Log("The Duck's costume is Unicorn :" + GameManager.uniDuck);
            buttonManager.UnicornActivation();
        }
        if(buttonManager.UB && buttonManager.PDB && buttonManager.SDB || (!gameManager.underwater && GameManager.scubDuck)){
            ChangeSprite(3);
            GameManager.regDuck = true;
            GameManager.artDuck = false;
            GameManager.uniDuck = false;
            GameManager.scubDuck = false;
        }
        if (Input.GetKeyDown (KeyCode.Alpha2) && buttonManager.PDB && coinCounter.currentCoins >= 5) {
            Debug.Log("2-artist");
            ChangeSprite(1);
            GameManager.regDuck = false;
            GameManager.uniDuck = false;
            GameManager.scubDuck = false;
            GameManager.artDuck = true;
            buttonManager.PaintDuckActivation();
        }
        
        if (Input.GetKeyDown (KeyCode.Alpha3) && gameManager.scubaAir && gameManager.underwater && buttonManager.SDB && coinCounter.currentCoins >= 5) {
            Debug.Log("3-scuba");

            ChangeSprite(2);
            gameManager.timeLeft = gameManager.timeLeft + 10;
            gameManager.scubaAir = false;
            gameManager.setTimer();
            GameManager.regDuck = false;
            GameManager.artDuck = false;
            GameManager.uniDuck = false;
            GameManager.scubDuck = true;
            buttonManager.ScubaDuckActivation();
        }
        
        

    }
    
    void ChangeSprite(int duckSprite) {
            spriteRenderer.sprite = spriteArray[duckSprite];
    }
}
