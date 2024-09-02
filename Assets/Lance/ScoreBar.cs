using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Image scoreBarFill; // Reference to the Image component for the fill
    public int maxTokens = 25; // Maximum number of tokens

    // Method to update the score bar fill amount
    public void UpdateScoreBar(int currentTokens)
    {
        float fillAmount = (float)currentTokens / maxTokens;
        scoreBarFill.fillAmount = fillAmount;
    }
}