using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add coin value to score
    public void AddCoin(int value) {
        score += value;
    }
}
