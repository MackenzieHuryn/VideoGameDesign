using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerController : MonoBehaviour
{
    public float speed = 3.4f;
    public float jumpHeight = 6.5f;
    public Camera mainCamera;
    bool facingRight = true;
    float moveDirection = 0;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    bool gameStart = true;

    // Start is called before the first frame update
    
    public float moveSpeed;
    //[Tooltip("The Y velocity set when the player jumps.  Changing the gravity scale on Rigidbody2D, to something like 3 to 4, can help to make this feel more snappy.")]
    public float jumpSpeed;
    //[Tooltip("Number of times the player can jump.")]
    public int jumps;
    //[Range(0, 0.8f), Tooltip("How quickly the player slows down while not moving.  Works better if the player has a zero friction physics material.")]
    public float drag;
    //[Range(0, 0.8f), Tooltip("How quickly the player speeds up to their desired velocity after pressing a key bind.  Works better if the player has a zero friction physics material.")]
    public float acceleration;

    [Header("Keybindings"), Space(10)]
    public KeyCode jumpKey;
    public KeyCode moveLeftKey;
    public KeyCode moveRightKey;

    Rigidbody2D rb;
    SpriteRenderer spr;
    [HideInInspector]
    public bool isGrounded = false;
    int editorValueJumps;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        editorValueJumps = jumps;
        rb.angularDrag = 0;
    }

    void Update()
    {
        if (Input.GetKey(moveLeftKey))
        {
            Vector2 vel = rb.velocity;
            vel.x = Mathf.Lerp(vel.x, -moveSpeed, acceleration);
            rb.velocity = vel;
        }
        else if (Input.GetKey(moveRightKey))
        {
            Vector2 vel = rb.velocity;
            vel.x = Mathf.Lerp(vel.x, moveSpeed, acceleration);
            rb.velocity = vel;
        }
        else if (!Input.GetKey(moveLeftKey) && !Input.GetKey(moveRightKey))
        {
            Vector2 vel = rb.velocity;
            vel.x = Mathf.Lerp(vel.x, 0, drag);
            rb.velocity = vel;
        }

        if (Input.GetKeyDown(jumpKey) && jumps > 0)
        {
            Vector2 vel = rb.velocity;
            vel.y = jumpSpeed;
            rb.velocity = vel;

            jumps -= 1;
        }
    }

    public void SetGround(bool groundBool)
    {
        isGrounded = groundBool;
        if (groundBool == true)
        {
            jumps = editorValueJumps;
        }
    }
}
