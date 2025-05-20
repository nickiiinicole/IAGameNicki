using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

/// <summary>
/// Controlador principal del menú de inicio.
/// Gestiona los paneles de inicio, victoria, derrota e introducción,
/// así como el inicio del juego, los sonidos y la transición entre escenas.
/// </summary>
public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject startPanel;  // Menú de inicio
    public GameObject winPanel;    // Pantalla de victoria
    public GameObject lostPanel;   // Pantalla de derrota
    public GameObject IntroPanel;  // Diálogo introductorio

    [Header("Audio Clips")]
    public AudioClip startSound;
    public AudioClip winSound;
    public AudioClip lostSound;

    [Header("Refs")]
    public PlayerController playerController; // Controlador del jugador
    public string gameLevelName = "FarmFinal"; // Nombre de la escena principal
    public TextMeshProUGUI introText; // Texto que se muestra durante la intro

    private AudioSource audioSource; // Fuente de audio local

    void Start()
    {
        // Obtiene el componente AudioSource en el mismo GameObject
        audioSource = GetComponent<AudioSource>();

        // Activa solo el panel de inicio al comenzar
        startPanel.SetActive(true);
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
        IntroPanel.SetActive(false);

        // Reproduce sonido de inicio
        PlaySound(startSound);
    }

    /// <summary>
    /// Método llamado al pulsar el botón de "Jugar".
    /// Oculta el panel de inicio, muestra la introducción, y habilita el control del jugador.
    /// </summary>
    public void PlayGame()
    {
        audioSource.Stop();
        startPanel.SetActive(false);

        // Muestra el diálogo de introducción
        StartCoroutine(ShowIntroDialogue());

        // Activa el control del jugador
        playerController.playerInControl = true;
    }

    /// <summary>
    /// Corutina que muestra un texto introductorio durante 5 segundos.
    /// </summary>
    IEnumerator ShowIntroDialogue()
    {
        IntroPanel.SetActive(true);
        introText.text = "Donde estoy... No veo nada... necesito que alguien me guie...";
        yield return new WaitForSeconds(5f);
        IntroPanel.SetActive(false);
    }

    /// <summary>
    /// Método llamado cuando el jugador pierde la partida.
    /// Desactiva el control y muestra el panel de derrota tras unos segundos.
    /// </summary>
    public void LostGame()
    {
        playerController.playerInControl = false;
        PlaySound(lostSound);
        Invoke("ShowLostPanelWithTimer", 3.0f);
    }

    /// <summary>
    /// Método llamado al ganar el juego. Muestra el panel de victoria.
    /// </summary>
    public void WinGame()
    {
        winPanel.SetActive(true);
        playerController.playerInControl = false;
        PlaySound(winSound);
    }

    /// <summary>
    /// Cierra la aplicación.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    /// <summary>
    /// Método auxiliar invocado tras una demora para mostrar el panel de derrota.
    /// </summary>
    void ShowLostPanelWithTimer()
    {
        lostPanel.SetActive(true);
    }

    /// <summary>
    /// Reinicia el nivel cargando la escena especificada por nombre.
    /// </summary>
    public void RestartLevel()
    {
        if (Application.CanStreamedLevelBeLoaded(gameLevelName))
        {
            SceneManager.LoadScene(gameLevelName);
        }
    }

    /// <summary>
    /// Reproduce un sonido específico mediante el AudioSource del objeto.
    /// </summary>
    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
