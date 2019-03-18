using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerShip;
    HealthComponent playerHealthComponent;
    PauseMenu pauseMenu;
    GameOverMenu gameOverMenu;
    LevelCompletedMenu levelCompletedMenu;

    EnemySpawner enemySpawner;
    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        gameOverMenu = FindObjectOfType<GameOverMenu>();
        levelCompletedMenu = FindObjectOfType<LevelCompletedMenu>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        playerHealthComponent = playerShip.GetComponent<HealthComponent>();

        playerHealthComponent.DeathEvent += PlayerHealthComponent_DeathEvent;

        enemySpawner.StartSpawn();
    }

    private void PlayerHealthComponent_DeathEvent()
    {
        gameOverMenu.ShowMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseMenu.IsPaused = !pauseMenu.IsPaused;
    }
}
