using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject playerShip;
    HealthComponent playerHealthComponent;
    PauseMenu pauseMenu;
    GameOverMenu gameOverMenu;
    LevelCompletedMenu levelCompletedMenu;
    EnemySpawner enemySpawner;

    bool isPause;
    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        gameOverMenu = FindObjectOfType<GameOverMenu>();
        levelCompletedMenu = FindObjectOfType<LevelCompletedMenu>();
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
        pauseMenu.ShowMenu();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        isPause = false;
        pauseMenu.HideMenu();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void EnemySpawner_AllEnemiesDestroyedEvent()
    {
        levelCompletedMenu.ShowMenu();
    }
    private void PlayerHealthComponent_DeathEvent()
    {
        gameOverMenu.ShowMenu();
    }

}
