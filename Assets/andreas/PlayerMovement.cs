using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    // Sprites for animations
    public Sprite idleSprite;
    public Sprite runSprite1;
    public Sprite runSprite2;
    public Sprite airSprite;  // Sprite for when the character is in the air

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // Reference to SpriteRenderer
    private bool isGrounded;

    private float animationTimer = 0f; // Timer to switch between run sprites
    private float animationInterval = 0.1f; // Time between sprite switches
    private bool isRunningSprite1 = true; // Toggle between run sprites

    public GameManager gameManager;
    public GameObject gameManagerObject;

    public int rubyPower = 1;
    private bool isAlive = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component

        // Set the initial sprite to the idle sprite
        spriteRenderer.sprite = idleSprite;

        //for connecting to gameManager
        gameManagerObject = GameObject.FindWithTag("GameController");
        
        if (gameManagerObject != null){
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        else {
            Debug.Log("uh oh! Game Manager not found");
        } 
    }

    private void Update()
    {
        Move();
        int newrubyPower = gameManager.GetRubies();
        if (newrubyPower > rubyPower){
            jumpForce += 1f;
        } 
        rubyPower = newrubyPower;
        Jump();
        Animate(); // Handle sprite animation
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Move the player
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the player sprite on the Y-axis based on direction
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void Animate()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // If in the air, show the air sprite
        if (!isGrounded)
        {
            spriteRenderer.sprite = airSprite;
        }
        else
        {
            // If not moving, show idle sprite
            if (Mathf.Approximately(moveInput, 0))
            {
                spriteRenderer.sprite = idleSprite;
            }
            else
            {
                // If moving, switch between run sprites
                animationTimer += Time.deltaTime;
                if (animationTimer >= animationInterval)
                {
                    animationTimer = 0f; // Reset timer
                    if (isRunningSprite1)
                    {
                        spriteRenderer.sprite = runSprite1;
                    }
                    else
                    {
                        spriteRenderer.sprite = runSprite2;
                    }
                    isRunningSprite1 = !isRunningSprite1; // Toggle between the two run sprites
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // kill player if collided with enemy
        if (collision.gameObject.CompareTag("Enemy")) {
            isAlive = false; 
            gameManager.EndGame();
        }
    }
}
