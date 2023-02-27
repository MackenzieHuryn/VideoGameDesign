using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray; // Holds possible costumes for player
    public Sprite newSprite; // The sprite that the player is changing to
    
    //NEED TO ADD SYSTEM TO HAVE A SPECIFIC NUMBER SENT INTO THE FUNCTION
    void ChangeSprite() {
            spriteRenderer.sprite = spriteArray[0];
    }
}
