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
    public float hzBound = 10;
    public float vtBound = 5;
    public float lowBound = -5;
    public float waterlineY;
    public float thrust = 20;

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
    public KeyCode jumpKey;
    public KeyCode moveLeftKey;
    public KeyCode moveRightKey;
    public KeyCode diveKey;
    public KeyCode jumpReal;

    Rigidbody2D rb;
    SpriteRenderer spr;
    [HideInInspector]
    public bool isGrounded = false;
    int editorValueJumps;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        //rb.angularDrag = 0;
    }

    void Update()
    {
        if(jumping == true && transform.position.y < waterlineY){
            //jumping = false;
            //rb.gravityScale = 0;
        }

        if (Input.GetKey(moveLeftKey) && (transform.position.x > -hzBound))
        {
            Vector2 vel = rb.velocity;
            vel.x = Mathf.Lerp(vel.x, -moveSpeed, acceleration);
            rb.velocity = vel;
        }
        else if (Input.GetKey(moveRightKey) && (transform.position.x < hzBound))
        {
            Vector2 vel = rb.velocity;
            vel.x = Mathf.Lerp(vel.x, moveSpeed, acceleration);
            rb.velocity = vel;
        }
        else if (!Input.GetKey(moveLeftKey) && !Input.GetKey(moveRightKey) || (transform.position.x > hzBound) || (transform.position.x < -hzBound))
        {
            Vector2 vel = rb.velocity;
            vel.x = Mathf.Lerp(vel.x, 0, drag);
            rb.velocity = vel;
        }


        if (Input.GetKeyDown(jumpKey) /*&& (transform.position.y < waterlineY)*/)
        {
                Vector2 vel = rb.velocity;
                vel.y = Mathf.Lerp(vel.y, moveSpeed, acceleration);
                rb.velocity = vel;
        }
        else if (Input.GetKeyDown(diveKey) /*&& (transform.position.y > lowBound)*/)
        {
            Vector2 vel = rb.velocity;
            vel.y = Mathf.Lerp(vel.y, -moveSpeed, acceleration);
            rb.velocity = vel;
        }
        else if(jumping = false && Input.GetKey(jumpReal)){
            doJump();
        }
        else if ((!Input.GetKey(jumpKey) && !Input.GetKey(diveKey)) || transform.position.y > waterlineY || transform.position.y < lowBound)
        {
            Vector2 vel = rb.velocity;
            vel.y = Mathf.Lerp(vel.y, 0, drag);
            rb.velocity = vel;
        }
    }

    public void doJump(){
        jumping = true;
        rb.gravityScale = 100; // Enable
        //rb.AddForce(transform.up * thrust);
    }

}
