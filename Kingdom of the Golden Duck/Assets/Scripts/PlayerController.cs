using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerController : MonoBehaviour
{
    
    /*public Camera mainCamera;
    bool facingRight = true;
    float moveDirection = 0;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    */

    //bool gameStart = true;
    bool onWater;
    bool underWater;
    bool jumping = false;
    public float rightBound = 10.0f;
    public float leftBound = 10.0f;
    public float upBound = 5.0f;
    public float lowBound = -5.0f;
    public float waterlineY;
    public float thrust = 20.0f;
    public float gravScale = 15.0f;
    public static float lives = 3f;
    private GameManager gameManager;
    private PlayerChangeSprite playerChangeSprite;
    public bool OnPlate = false;


    // Start is called before the first frame update
    
    public float moveSpeed;
    //[Tooltip("The Y velocity set when the player jumps.  Changing the gravity scale on Rigidbody2D, to something like 3 to 4, can help to make this feel more snappy.")]
    public float jumpSpeed;
    //[Tooltip("Number of times the player can jump.")]
    //public int jumps;
    //[Range(0, 0.8f), Tooltip("How quickly the player slows down while not moving.  Works better if the player has a zero friction physics material.")]
    public float drag;
    //[Range(0, 0.8f), Tooltip("How quickly the player speeds up to their desired velocity after pressing a key bind.  Works better if the player has a zero friction physics material.")]
    public float acceleration;

    //[Header("Keybindings"), Space(10)]
    public KeyCode upKey;
    public KeyCode moveLeftKey;
    public KeyCode moveRightKey;
    public KeyCode diveKey;
    public KeyCode jumpReal;

    public 
    Rigidbody2D rb;
    SpriteRenderer spr;
    [HideInInspector]
    public bool isGrounded = false;
    int editorValueJumps;

    //private HashSet<GameObject> touching = new HashSet<GameObject>();

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //rb.angularDrag = 0;
    }

    void Update()
    {
        if(transform.position.y < waterlineY - 0.1){
            gameManager.underwater = true;
            
        }else{
            gameManager.underwater = false;
            gameManager.timeLeft = 5.0f;
            gameManager.setTimer();
            gameManager.scubaAir = true;
            
        }
         
       if(gameManager.underwater && gameManager.timeLeft == 0)
       {
            lives--;
            gameManager.timeLeft = 5.0f;
            gameManager.setTimer();
       }

        
        if(jumping == true && transform.position.y  < waterlineY){
            jumping = false;
            rb.gravityScale = 0;
            Vector2 vel = rb.velocity;
            vel.y = Mathf.Lerp(vel.y, 0, drag);
            vel.x = Mathf.Lerp(vel.x, 0, drag);
            rb.velocity = vel;
            //transform.position = new Vector2(transform.position.x, waterlineY);
        }
        if (transform.position.x < leftBound){
            transform.position = new Vector2(leftBound, transform.position.y);
        }
        if (Input.GetKey(moveLeftKey))
        {
            Vector2 vel = rb.velocity;
            vel.x = Mathf.Lerp(vel.x, -moveSpeed, acceleration);
            rb.velocity = vel;
        }
        if (transform.position.x > rightBound){
            transform.position = new Vector2(rightBound, transform.position.y);
        }
        if (Input.GetKey(moveRightKey))
        {
            Vector2 vel = rb.velocity;
            vel.x = Mathf.Lerp(vel.x, moveSpeed, acceleration);
            rb.velocity = vel;
        }
        if (!Input.GetKey(moveLeftKey) && !Input.GetKey(moveRightKey))
        {
            Vector2 vel = rb.velocity;
            vel.x = Mathf.Lerp(vel.x, 0, drag);
            rb.velocity = vel;
        }

        if (jumping == false && transform.position.y > waterlineY){
            transform.position = new Vector2(transform.position.x, waterlineY);
        }
      
        if(OnPlate ==true && Input.GetKey(jumpReal)){
            doJump();
        }else if(jumping == false && Input.GetKey(jumpReal) && (transform.position.y >= waterlineY - 0.1)){
            doJump();
        } else if (jumping == false && Input.GetKeyDown(upKey) && !Input.GetKey(jumpReal) && (transform.position.y <= waterlineY))
        {
                Vector2 vel = rb.velocity;
                vel.y = Mathf.Lerp(vel.y, moveSpeed, drag);
                rb.velocity = vel;
        }else if (jumping == false && Input.GetKeyDown(diveKey) && !Input.GetKey(jumpReal) && (transform.position.y <= waterlineY))
        {
            Vector2 vel = rb.velocity;
            vel.y = Mathf.Lerp(vel.y, -moveSpeed, acceleration);
            rb.velocity = vel;
        }

        if (transform.position.y < lowBound){
            transform.position = new Vector2(transform.position.x, lowBound);
        }
        if ((!Input.GetKey(upKey) && !Input.GetKey(diveKey)))
        {
            Vector2 vel = rb.velocity;
            vel.y = Mathf.Lerp(vel.y, 0, drag);
            rb.velocity = vel;
        }
    }

    /*public void drowning(float waitTime)
    {
        float timeSinceStarted = 0f;
        float secDiff = 2.0f;
        float counter = 1.0f;
        while(true){
            timeSinceStarted += Time.deltaTime;
            if(!gameManager.underwater){
                break;
            }
            if(timeSinceStarted > secDiff * counter){
                counter++;
                lives--;
            }
        }
    }*/
    public void doJump(){
        //Vector3 dirY = transform.up * thrust;
        //rb.AddForce(new Vector2 (0, dirY.y));
        //Vector2 vel = rb.velocity;
        //transform.Translate(Vector2.up * Time.deltaTime * thrust * 0.5f);
        //transform.Translate(new Vector2(0.0f, Time.deltaTime * thrust * 0.5f));
       float timeSinceStarted = 0f;
        while(true){
            timeSinceStarted += Time.deltaTime;
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y + 4);
            transform.position = Vector2.Lerp(transform.position, newPos, timeSinceStarted);
            if (transform.position.y >= 4)
            {
                break;
            }

        }
        jumping = true;
        rb.gravityScale = gravScale; // Enable gravity
        //transform.position = newPos;
        //transform.position = Vector2.MoveTowards(transform.position, newPos, Time.deltaTime);
        
   
    }

    //runs this code when the player collides with an enemy
    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("Collision");
        if (collision.gameObject.tag == "Enemy" ){ 
            // Remove Lives
            Debug.Log("Life Lost! Lives left:" + lives);
            lives--;
        }
        if (collision.gameObject.tag == "Platform" ){ 
           OnPlate = true;
           //onPlatform();
           /*if (Input.GetKey(jumpReal)){
               
               Debug.Log("PlatformJump");
               float timeSinceStarted = 0f;
               float jumpVal = collision.gameObject.transform.position.y + 4;
               while(true){
                    timeSinceStarted += Time.deltaTime; 
                    Vector2 newPos = new Vector2(transform.position.x, jumpVal);
                    transform.position = Vector2.Lerp(transform.position, newPos, timeSinceStarted);
                    if (transform.position.y >= jumpVal)
                    {
                        break;
                    }*/

        }

     }
     private void OnCollisionExit2D(Collision2D collision){
          if (collision.gameObject.tag == "Platform" ){ 
            OnPlate = false;
          }
     }
     

  }
    
 


