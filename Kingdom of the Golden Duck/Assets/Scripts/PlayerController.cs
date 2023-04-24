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
    public float gravScale = 5.0f;
    public static float lives = 3f;
    public float jumpPower = 5.0f;
    private GameManager gameManager;
    private PlayerChangeSprite playerChangeSprite;
    public bool OnPlate = false;


    // For player color change/flashing
    private SpriteRenderer spriteRenderer;
    private Color red;
    private Color white;

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

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        red = new Color(1, 0.4f, 0.4f, 1);
        white = new Color(1, 1, 1, 1);
    }

    void Update()
    {
        if (gameManager.isGameActive) {
            if(transform.position.y < waterlineY - 1.2){

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
            StartCoroutine(FlashRed());
            gameManager.timeLeft = 5.0f;
            gameManager.setTimer();
        }


        if(transform.position.y < waterlineY){

            rb.gravityScale = 0;
            if(jumping){
                jumping = false;
                Vector2 vel = rb.velocity;
                vel.y = Mathf.Lerp(vel.y, 0, acceleration);
                vel.x = Mathf.Lerp(vel.x, 0, acceleration);
                rb.velocity = vel;
                transform.position = new Vector2(transform.position.x, waterlineY + 1.2f);
            }

            
        } 

        if (transform.position.x < leftBound){
            transform.position = new Vector2(leftBound, transform.position.y);
        }

        if ( transform.position.y > upBound){
             transform.position = new Vector2(transform.position.x, upBound);
        }
        if (Input.GetKey(moveLeftKey)) {
            Vector2 vel = rb.velocity;
            vel.x = Mathf.Lerp(vel.x, -moveSpeed, acceleration);
            rb.velocity = vel;
        }

        if (transform.position.x > rightBound){
            transform.position = new Vector2(rightBound, transform.position.y);
        }

        if (Input.GetKey(moveRightKey)) {
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
      
        if((OnPlate == true) && Input.GetKey(jumpReal)){
            jumping = true;
            rb.gravityScale = gravScale;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);    
        
            //doJump();

        } else if(jumping == false && Input.GetKey(jumpReal) && (transform.position.y >= waterlineY)){
            jumping = true;
            rb.gravityScale = gravScale;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);    
            //doJump();

        } 
        if (jumping == false && Input.GetKeyDown(upKey) && (transform.position.y <= waterlineY))
        {
            Vector2 vel = rb.velocity;
            vel.y = Mathf.Lerp(vel.y, moveSpeed, acceleration);
            rb.velocity = vel;

        }
        if (jumping == false && Input.GetKeyDown(diveKey) && (transform.position.y <= waterlineY))
        {
            Vector2 vel = rb.velocity;
            vel.y = Mathf.Lerp(vel.y, -moveSpeed, acceleration);
            rb.velocity = vel;
        }

        if (transform.position.y < lowBound){
            transform.position = new Vector2(transform.position.x, lowBound);
        }

        if ((!Input.GetKey(upKey) && !Input.GetKey(diveKey)) && gameManager.underwater)
        {
            Vector2 vel = rb.velocity;
            vel.y = Mathf.Lerp(vel.y, 0, acceleration);
            rb.velocity = vel;
        }
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
       float jumpPos = transform.position.y + 4;
       jumping = true;
       rb.gravityScale = gravScale;
        while(true){
            timeSinceStarted += Time.deltaTime;
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y + 4);
            transform.position = Vector2.Lerp(transform.position, newPos, timeSinceStarted);
            if (transform.position.y >= jumpPos)
            {
                break;
            }

        }
        // Enable gravity
        //transform.position = newPos;
        //transform.position = Vector2.MoveTowards(transform.position, newPos, Time.deltaTime);
        
   
    }

    //runs this code when the player collides with an enemy, platform, or the golden duck
    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("Collision");
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyFish"){ 
            if(GameManager.uniDuck){
                if (collision.gameObject.tag == "EnemyFish") { 
                    EnemySpawn.fishSpawned--;
                    // Destroys object it collides with
                    Destroy(collision.gameObject);
         
                }
                if (collision.gameObject.tag == "Enemy") {
                 // Destroys object it collides with
                Destroy(collision.gameObject);
                EnemySpawn.badDuckSpawned = 0f;
                }
            
            }else{
            // Remove Lives
            //Debug.Log("Life Lost! Lives left:" + lives);
            lives--;
            StartCoroutine(FlashRed());
            }

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
        if (collision.gameObject.tag == "EndLevel"){ 
            Debug.Log("Golden Duck!!");
           gameManager.GoldenDuck();
        }

     }
     private void OnCollisionExit2D(Collision2D collision){
          if (collision.gameObject.tag == "Platform" ){ 
            OnPlate = false;

          }
     }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = red;
        yield return new WaitForSeconds(0.15f);
        spriteRenderer.color = white;
    }

}
    
 


 



