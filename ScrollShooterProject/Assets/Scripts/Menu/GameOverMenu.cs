using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button restartButton;
    public Button mainMenuButton;
    GameController gameController;
    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        restartButton.onClick.AddListener(gameController.Restart);
        mainMenuButton.onClick.AddListener(gameController.MainMenu);
        gameController.GameOverEvent += GameOverEventHandler;
    }
    private void GameOverEventHandler()
    {
        ShowMenu();
    }
    public void ShowMenu()
    {
        gameOverPanel.SetActive(true);
    }
    public void HideMenu()
    {
        gameOverPanel.SetActive(false);
    }
}
