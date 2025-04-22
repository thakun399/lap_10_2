using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int currentScore = 0;
    public TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
