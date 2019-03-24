using UnityEngine;
using System;

public class ScoreContoller : MonoBehaviour
{
    public event Action<int> ScoreChangedEvent;
    int score;
    public int Score { get { return score; } }
    public void AddScore(int amount)
    {
        score += amount;
        if (ScoreChangedEvent != null)
            ScoreChangedEvent(score);
    }
}
