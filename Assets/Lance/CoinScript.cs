using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // The value of the coin
    public GameObject gameManagerObject; 
    public GameManager gameManager; 

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
                // Add coin value to player's score
                gameManager.AddScore(coinValue);

                // Make the coin disappear
                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("GameManager reference is missing.");
            }
        }
    }
}
