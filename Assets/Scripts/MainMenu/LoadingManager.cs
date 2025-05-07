using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadGameAsync());
    }

    // declara una corutina , que se usara para cargar la escena en 2do plano sin congelar el juego
    IEnumerator LoadGameAsync()
    {
        //aqui espera 1 segundo antes de continuar 
       yield return new WaitForSeconds(1f); 
        //comineza la carga asincrona , este devuelve un obj de tio AsyncOperation que nos dice cuanto ha cargado la scene
        //y si ya esta terminada op.isDone 
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneLoader.scene);

        while (!op.isDone)//el bucle se repite hasta no haber terminado cargar 
        {
            yield return null; // aca espera al siguiente frame y vuelve a comprobar
        }
    }
  
}
