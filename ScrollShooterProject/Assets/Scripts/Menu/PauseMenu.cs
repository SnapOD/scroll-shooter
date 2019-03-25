using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Button resumeButton;
    public Button mainMenuButton;
    public Button quitButton;
    [Space]
    public Button pauseButton;

    private void Start()
    {
        GameController gameController = FindObjectOfType<GameController>();
        resumeButton.onClick.AddListener(gameController.Resume);
        mainMenuButton.onClick.AddListener(gameController.MainMenu);
        quitButton.onClick.AddListener(gameController.Quit);
        pauseButton.onClick.AddListener(gameController.Pause);

        gameController.PauseEvent += PauseEventHandler;
        gameController.ResumeEvent += ResumeEventHandler;
        gameController.GameOverEvent += GameOverEventHandler;
        gameController.LevelCompletedEvent += LevelCompletedEventHandler;
    }
    private void PauseEventHandler()
    {
        ShowMenu();
    }
    private void ResumeEventHandler()
    {
        HideMenu();
    }
    private void LevelCompletedEventHandler()
    {
        pauseButton.gameObject.SetActive(false);
    }
    private void GameOverEventHandler()
    {
        pauseButton.gameObject.SetActive(false);
    }
    public void ShowMenu()
    {
        pauseMenuPanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
    public void HideMenu()
    {
        pauseMenuPanel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
}
