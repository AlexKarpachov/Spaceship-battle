using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public static int ScoreValue { get; private set; }
    public TextMeshProUGUI ScoreText;

    private void Start()
    {
        // Load the score from PlayerPrefs when the level starts
        ScoreValue = PlayerPrefs.GetInt("PlayerScore", 0);
        UpdateScoreText();
    }
    public void AddScore(int score)
    {
        // Add the enemy score to the total score
        ScoreValue += score;
        UpdateScoreText();
        SaveScore();
    }
    public void ResetScore()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 0)
        {
            ScoreValue = 0;
            UpdateScoreText();
            PlayerPrefs.SetInt("PlayerScore", ScoreValue);
        }
    }

    private void UpdateScoreText()
    {
        ScoreText.text = "Score: " + ScoreValue;
    }

    private void SaveScore()
    {
        // Save the score to PlayerPrefs
        PlayerPrefs.SetInt("PlayerScore", ScoreValue);
    }
}
