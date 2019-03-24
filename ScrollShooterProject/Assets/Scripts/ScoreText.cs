using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text scoreText;
    ScoreContoller scoreContoller;
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreContoller = FindObjectOfType<ScoreContoller>();
        scoreContoller.ScoreChangedEvent += ScoreContoller_ScoreChangedEvent;
        scoreText.text = scoreContoller.Score.ToString();
    }
    private void ScoreContoller_ScoreChangedEvent(int obj)
    {
        scoreText.text = obj.ToString();
    }
}
