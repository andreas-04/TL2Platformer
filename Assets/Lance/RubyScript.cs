using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyScript : MonoBehaviour
{
    float jumpPowerUp = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
            else
            {
                Debug.LogError("GameManager reference is missing.");
            }
        }
    }
}
