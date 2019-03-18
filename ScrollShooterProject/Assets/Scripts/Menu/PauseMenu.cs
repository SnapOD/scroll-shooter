using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    [SerializeField] bool isPaused;
    public bool IsPaused
    {
        get { return isPaused; }
        set
        {
            isPaused = value;
            UpdateState();
        }
    }
    private void Start()
    {
        UpdateState();
    }
    private void UpdateState()
    {
        pauseMenuPanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }
    public void Resume()
    {
        isPaused = false;
        UpdateState();
    }
    public void MainMenu()
    {
        isPaused = false;
        UpdateState();
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
