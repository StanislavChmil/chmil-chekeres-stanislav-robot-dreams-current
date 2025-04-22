using UnityEngine;
using TMPro; // Используем TMP вместо UnityEngine.UI

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Заменили тип

    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}