using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int numCoinsCollected = 0;
    public int numRubiesCollected = 0;
    public int numCoinsInLevel = 25;
    public ScoreBar scoreBar;
    public TextMeshProUGUI winMessage;
    public GameObject gameOverScreen;

    public AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        numCoinsCollected = 0;
        numRubiesCollected = 0;
        AudioListener.pause = false;
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
        CheckEndGame();
    }

    // Ends game when all coins have been collected
    public void CheckEndGame() {
        if (numCoinsCollected == numCoinsInLevel) {
            EndGame();
        }
    }

    // Ends game
    public void EndGame() {
        if (numCoinsCollected == numCoinsInLevel) {
            winMessage.SetText("You Won");
            AudioListener.pause = true;
            audioManager.PlaySFX(audioManager.win);
        } else {
            winMessage.SetText("You Lost");
            AudioListener.pause = true;
            audioManager.PlaySFX(audioManager.dead);
        }

        //GameObject.FindWithTag("Player").SetActive(false);
        gameOverScreen.SetActive(true);
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
