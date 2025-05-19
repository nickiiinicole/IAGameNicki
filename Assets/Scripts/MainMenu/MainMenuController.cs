using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject startPanel;
    public GameObject winPanel;
    public GameObject lostPanel;
    public GameObject IntroPanel;

    [Header("Audio Clips")]
    public AudioClip startSound;
    public AudioClip winSound;
    public AudioClip lostSound;

    [Header("Refs")]
    public PlayerController playerController;
    public string gameLevelName = "FarmFinal";
    public TextMeshProUGUI introText; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        startPanel.SetActive(true);
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
        IntroPanel.SetActive(false);

        PlaySound(startSound);
    }

    public void PlayGame()
    {
        audioSource.Stop();
        startPanel.SetActive(false);

        // Mostrar introducción
        StartCoroutine(ShowIntroDialogue());

        playerController.playerInControl = true;
    }

    IEnumerator ShowIntroDialogue()
    {
        IntroPanel.SetActive(true);
        introText.text = "Donde estoy... No veo nada... necesito que alguien me guie...";
        yield return new WaitForSeconds(5f); 
        IntroPanel.SetActive(false);
    }

    public void LostGame()
    {
        playerController.playerInControl = false;
        PlaySound(lostSound);
        Invoke("ShowLostPanelWithTimer", 3.0f);
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        playerController.playerInControl = false;
        PlaySound(winSound);
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

    public void RestartLevel()
    {
        if (Application.CanStreamedLevelBeLoaded(gameLevelName))
        {
            SceneManager.LoadScene(gameLevelName);
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
