using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public event Action PauseEvent;
    public event Action ResumeEvent;
    public event Action GameOverEvent;
    public event Action LevelCompletedEvent;
    public event Action MainMenuEvent;
    public event Action RestartEvent;
    public event Action QuitEvent;
    public GameObject playerShip;

    EnemySpawner enemySpawner;
    HealthComponent playerHealthComponent;

    bool isPause;
    bool isEnemiesDestroyed;
    bool isPlayerDestroyed;
    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.AllEnemiesDestroyedEvent += EnemySpawner_AllEnemiesDestroyedEvent;
        enemySpawner.StartSpawn();
        playerHealthComponent = playerShip.GetComponentInChildren<HealthComponent>();
        playerHealthComponent.DeathEvent += PlayerHealthComponent_DeathEvent;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
                Resume();
            else
                Pause();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        isPause = true;
        if (PauseEvent != null) PauseEvent();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        isPause = false;
        if (ResumeEvent != null) ResumeEvent();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        if (RestartEvent != null) RestartEvent();
        SceneManager.LoadScene("Level");
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        if (RestartEvent != null) RestartEvent();
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        if (QuitEvent != null) QuitEvent();
        Application.Quit();
    }
    private void EnemySpawner_AllEnemiesDestroyedEvent()
    {
        if (!isPlayerDestroyed)
        {
            isEnemiesDestroyed = true;
            if (LevelCompletedEvent != null)
                LevelCompletedEvent();
        }
    }
    private void PlayerHealthComponent_DeathEvent()
    {
        if (!isEnemiesDestroyed)
        {
            isPlayerDestroyed = true;
            if (GameOverEvent != null)
                GameOverEvent();
        }
    }

}
