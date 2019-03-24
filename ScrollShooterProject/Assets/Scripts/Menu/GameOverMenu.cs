using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button restartButton;
    public Button mainMenuButton;
    private void Start()
    {
        restartButton.onClick.AddListener(FindObjectOfType<GameController>().Restart);
        mainMenuButton.onClick.AddListener(FindObjectOfType<GameController>().MainMenu);
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
