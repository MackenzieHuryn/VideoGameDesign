using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthColor : MonoBehaviour
{

    public int playerHealth;
    private SpriteRenderer spriteRenderer;
    private Color red;
    private Color white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (playerHealth == 0)
        {
            deathScreenController.fadeIn = true;
        }*/
    }

    public void damagePlayer()
    {
        playerHealth -= 1;
        StartCoroutine(FlashRed());
    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = red;
        yield return new WaitForSeconds(0.12f);
        spriteRenderer.color = white;
    }
}
