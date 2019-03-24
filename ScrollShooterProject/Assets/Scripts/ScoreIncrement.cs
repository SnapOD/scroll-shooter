using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrement : MonoBehaviour
{
    public int score;
    HealthComponent healthComponent;
    ScoreContoller scoreContoller;

    void Start()
    {
        scoreContoller = FindObjectOfType<ScoreContoller>();
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.DeathEvent += HealthComponent_DeathEvent;
    }
    private void HealthComponent_DeathEvent()
    {
        scoreContoller.AddScore(score);
    }
}
