using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class VoiceCommandHandler : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions;

    public PlayerController playerController;

    void Start()
    {
        actions = new Dictionary<string, System.Action>
        {
            { "play", StartMoving },
            { "start", StartMoving },
            { "stop", StopMoving },
            { "pause", StopMoving },
            { "avanzar", MoveForward },
            { "hacia adelante", MoveForward },
            { "vamos hacia adelante", MoveForward },
            { "hacia atras", MoveBackward },
            { "vamos hacia atras", MoveBackward },
            { "shoot", Shoot},
            { "dispara", Shoot}
        };

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordRecognized;
        keywordRecognizer.Start();
    }

    void OnKeywordRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword Recognized: " + args.text);
        actions[args.text]?.Invoke();
    }
    void Shoot()
    {
        if (playerController != null)
        {
            playerController.TriggerShootAnimation();
        }
    }

    void StartMoving()
    {
        Debug.Log("Comenzar movimiento");
        // Puedes poner un destino por defecto
        MoveForward();
    }

    void StopMoving()
    {
        Debug.Log("Detener movimiento");
        playerController.StopMovement();
    }

    public void MoveForward()
    {
        if (playerController == null) return;

        Vector3 forwardDirection = playerController.transform.forward;
        Vector3 targetPosition = playerController.transform.position + forwardDirection * 3f; // Avanza 3 metros
        playerController.MoveTo(targetPosition);
    }

    public void MoveBackward()
    {
        if (playerController == null) return;

        Vector3 backwardDirection = -playerController.transform.forward;
        Vector3 targetPosition = playerController.transform.position + backwardDirection * 3f; // Retrocede 3 metros
        playerController.MoveTo(targetPosition);
    }

}
