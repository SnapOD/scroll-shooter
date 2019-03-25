using UnityEngine;
using UnityEngine.UI;

public class LevelCompletedMenu : MonoBehaviour
{
    public GameObject levelCompletedPanel;
    public Button restartButton;
    public Button mainMenuButton;
    GameController gameController;
    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        restartButton.onClick.AddListener(gameController.Restart);
        mainMenuButton.onClick.AddListener(gameController.MainMenu);
        gameController.LevelCompletedEvent += GameController_LevelCompletedEvent;
    }
    private void GameController_LevelCompletedEvent()
    {
        ShowMenu();
    }
    public void ShowMenu()
    {
        levelCompletedPanel.SetActive(true);
    }
    public void HideMenu()
    {
        levelCompletedPanel.SetActive(false);
    }
}
