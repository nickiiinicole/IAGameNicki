using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public Slider progressBar;
    public string sceneToLoad = "FarmFinal";

    void Start()
    {
        StartCoroutine(LoadGameAsync());
    }

    // declara una corutina , que se usara para cargar la escena en 2do plano sin congelar el juego
    IEnumerator LoadGameAsync()
    {


        //comineza la carga asincrona , este devuelve un obj de tio AsyncOperation que nos dice cuanto ha cargado la scene
        //y si ya esta terminada op.isDone 
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneToLoad);
        op.allowSceneActivation = false;

        while (!op.isDone)//el bucle se repite hasta no haber terminado cargar 
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            progressBar.value = progress;
            if (op.progress >= 0.9f)
            {
                {//aqui espera 1 segundo antes de continuar 0    
                    yield return new WaitForSeconds(0.5f);
                    op.allowSceneActivation = true;
                }

                yield return null; // aca espera al siguiente frame y vuelve a comprobar
            }
        }

    }
}
