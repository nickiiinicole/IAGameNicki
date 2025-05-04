using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string scene;

    public static void LoadScene(string sceneName)
    {
        scene = sceneName;
        // permite cargar una escena con transición a la escena de carga
        SceneManager.LoadScene("LoadingScene");
    }
}
