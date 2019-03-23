using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    public void ShowMenu()
    {
        gameOverPanel.SetActive(true);
    }
    public void HideMenu()
    {
        gameOverPanel.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
