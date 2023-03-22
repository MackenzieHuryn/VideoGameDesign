using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    // Booleans for what costumes the duck is wearing
    // They are static so that they can be referenced from other scripts
    public static bool regDuck = true;
    public static bool uniDuck = false;
    public static bool artDuck = false;
    public static bool scubDuck = false;
    

    // GameObject variables
    private GameObject life1;
    private GameObject life2;
    private GameObject life3;

    public float breath = 5.0f;
    public float timeLeft = 5.0f;
    [SerializeField]
    public TextMeshProUGUI airTime;
    public bool underwater = false;
    public bool scubaAir = true;

    // Boolen for when game is running / over
    public bool isGameActive;
    // public Button restartButton; // Restart button

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        
        life1 = GameObject.Find("heart 1");
        life2 = GameObject.Find("heart 2");
        life3 = GameObject.Find("heart 3");
    
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        
        if(isGameActive) {
            
        // Make sure number of lives left is reflected in hearts shown on screen
            if (PlayerController.lives == 3) {
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
            }
            if (PlayerController.lives == 2) {
                life1.SetActive(true);
                life2.SetActive(true);
                // Remove heart 3
                life3.SetActive(false);
            } else if (PlayerController.lives == 1) {
                // Remove heart 2
                life1.SetActive(true);
                life2.SetActive(false);
                life3.SetActive(false);
            } else if (PlayerController.lives <= 0) {
                
                // Remove heart 1
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
            
                
                GameOver(); 
            }
            if(underwater){
                if(timeLeft > 0){
                    timeLeft = timeLeft - Time.deltaTime;
                } else{
                    timeLeft = 0;
                }
                airTime.text = "Air: " + timeLeft;
            }
        }
    }

    public void GameOver() {
        isGameActive = false;
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
        PlayerController.lives = 3f;
        EnemySpawn.fishSpawned = 0f;
        EnemySpawn.badDuckSpawned = 0f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void setTimer(){
        airTime.text = "Air: " + timeLeft;
    }

    

    
}
