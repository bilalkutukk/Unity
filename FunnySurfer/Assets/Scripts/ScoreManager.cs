using UnityEngine;
using TMPro;
using UnityEditor.Rendering;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = "Score: " + (score).ToString();
    }
}
    
