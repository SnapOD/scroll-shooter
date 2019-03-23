using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedMenu : MonoBehaviour
{
    public GameObject levelCompletedPanel;
    public void ShowMenu()
    {
        levelCompletedPanel.SetActive(true);
    }
    public void HideMenu()
    {
        levelCompletedPanel.SetActive(false);
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
