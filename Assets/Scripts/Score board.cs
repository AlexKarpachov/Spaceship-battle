using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score;
    TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: 0";
    }
    public void ScoreCalculation(int addToScore)
    {
        score += addToScore;
        scoreText.text = "Score: " + score.ToString();
    }
}
