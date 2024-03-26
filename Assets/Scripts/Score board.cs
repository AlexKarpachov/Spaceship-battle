using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score;

    public void ScoreCalculation(int addToScore)
    {
        score += addToScore;
        Debug.Log($"Current score is {score}");
    }
}
