using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject optionsPanel;

    public void PlayGame()
    {
        //SceneManager.LoadScene("FarmFinal"); 
        SceneLoader.LoadScene("FarmFinal");
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
