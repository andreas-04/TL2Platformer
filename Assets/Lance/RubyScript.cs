using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyScript : MonoBehaviour
{
    float jumpPowerUp = 1f;
    public GameObject gameManagerObject; 
    public GameManager gameManager; 


    public AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // Find the GameObject with the tag "GameController"
        gameManagerObject = GameObject.FindWithTag("GameController");

        // Get the GameManager component from the GameObject
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("GameManager GameObject not found with tag 'GameController'.");
        }
    }

    // Call when coin body has collided with another GameObject
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with the coin is the player
        if (other.CompareTag("Player"))
        {
            // Ensure the gameManager reference is not null
            if (gameManager != null)
            {
                // Add one more to number of rubies collected
                gameManager.AddNumRubies();

                // TODO add the jumpPowerUp to the player so they jump higher

                // Make the coin disappear
                gameObject.SetActive(false);
                audioManager.PlaySFX(audioManager.coinget);

            }
            else
            {
                Debug.LogError("GameManager reference is missing.");
            }
        }
    }
}
