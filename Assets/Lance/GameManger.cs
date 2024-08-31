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
    public void EndGame() {
        if (numCoinsCollected == numCoinsInLevel) {
            // TODO END THE GAME
        }
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
