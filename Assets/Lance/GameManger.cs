using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int numCoinsCollected = 0;
    public int numRubiesCollected = 0;
    public int numCoinsInLevel = 25;
    public ScoreBar scoreBar;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        numCoinsCollected = 0;
        numRubiesCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add coin value to score
    public void AddScore(int value) {
        score += value;
        numCoinsCollected += 1;
        scoreBar.UpdateScoreBar(numCoinsCollected);
    }

    // Ends game when all coins have been collected
    public void CheckEndGame() {
        if (numCoinsCollected == numCoinsInLevel) {
            EndGame();
        }
    }

    // Ends game
    public void EndGame() {
        Debug.Log("Game over");
        if (numCoinsCollected == numCoinsInLevel) {
            Debug.Log("Player Wins!");
        } else {
            Debug.Log("You lost!");
        }

        GameObject.FindWithTag("Player").SetActive(false);
        Time.timeScale = 0;
    }

    // Add coin value to score
    public void AddNumRubies() {
        Debug.Log(numRubiesCollected);
        numRubiesCollected += 1;
    }

    // get number of rubies collected
    public int GetRubies() {
        return numRubiesCollected;
    }

    // get number of coins collected
    public int GetCoins() {
        return numCoinsCollected;
    }
}
