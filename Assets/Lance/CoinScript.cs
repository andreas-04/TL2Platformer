using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // The value of the coin
    public GameObject gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with the coin is the player
        if (other.CompareTag("Player"))
        {
            // Add coin value to player's score
            //gameManager.addScore(coinValue);

            // make the coin dissapear
            gameObject.SetActive(false);
        }
    }
}
