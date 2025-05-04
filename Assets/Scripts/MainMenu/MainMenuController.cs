using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene("FarmFinal"); 
        SceneLoader.LoadScene("FarmFinal");
    }

    public void OpenOptions()
    {
        Debug.Log("Opciones todav�a no implementadas.");
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
