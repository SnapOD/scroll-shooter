using UnityEngine;
using UnityEngine.UI;

public class LevelCompletedMenu : MonoBehaviour
{
    public GameObject levelCompletedPanel;
    public Button restartButton;
    public Button mainMenuButton;
    private void Start()
    {
        restartButton.onClick.AddListener(FindObjectOfType<GameController>().Restart);
        mainMenuButton.onClick.AddListener(FindObjectOfType<GameController>().MainMenu);
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
