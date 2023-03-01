using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray; // Holds possible costumes for player

    
    void Update() {
        if (Input.GetKeyDown (KeyCode.Alpha1)) {
            Debug.Log("1-unicorn");
            GameManager.regDuck = false;
            GameManager.uniDuck = true;
            ChangeSprite(0);
            Debug.Log("The Duck's costume is Unicorn :" + GameManager.uniDuck);
        }
        if (Input.GetKeyDown (KeyCode.Alpha2)) {
            Debug.Log("2-artist");
            ChangeSprite(1);
            GameManager.regDuck = false;
            GameManager.artDuck = true;
        }
        if (Input.GetKeyDown (KeyCode.Alpha3)) {
            Debug.Log("3-scuba");
            ChangeSprite(2);
            GameManager.regDuck = false;
            GameManager.scubDuck = true;
        }


    }
    
    //NEED TO ADD SYSTEM TO HAVE A SPECIFIC NUMBER SENT INTO THE FUNCTION
    void ChangeSprite(int duckSprite) {
            spriteRenderer.sprite = spriteArray[duckSprite];
    }
}
