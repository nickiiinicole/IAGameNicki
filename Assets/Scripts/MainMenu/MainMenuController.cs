using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject winPanel;
    public GameObject lostPanel;
    public PlayerController playerController;
    public string gameLevelName = "FarmFinal";

    public void Start()
    {
        startPanel.SetActive(true);
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
    }

    public void PlayGame()
    {
        startPanel.SetActive(false);
        playerController.playerInControl = true;
    }

    public void LostGame()
    {
        playerController.playerInControl = false;
        Invoke("ShowLostPanelWithTimer", 3.0f);
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        playerController.playerInControl = false;
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    void ShowLostPanelWithTimer()
    {
        lostPanel.SetActive(true);
    }

    public void RestartLevel() {
        if (Application.CanStreamedLevelBeLoaded(gameLevelName))
        {
            SceneManager.LoadScene(gameLevelName);
        }
    }

}
