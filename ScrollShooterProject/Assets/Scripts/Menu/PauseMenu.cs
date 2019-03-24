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
        GameController gc = FindObjectOfType<GameController>();
        resumeButton.onClick.AddListener(gc.Resume);
        mainMenuButton.onClick.AddListener(gc.MainMenu);
        quitButton.onClick.AddListener(gc.Quit);
        pauseButton.onClick.AddListener(gc.Pause);
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
