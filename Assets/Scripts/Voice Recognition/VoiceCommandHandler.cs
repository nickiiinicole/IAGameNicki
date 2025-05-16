using UnityEngine;
using UnityEngine.Windows.Speech; // Necesario para usar reconocimiento de voz
using System.Collections.Generic;
using System.Linq;

public class VoiceCommandHandler : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer; // Componente que reconoce palabras clave habladas
    private Dictionary<string, System.Action> actions; // Diccionario que asocia palabras clave a acciones
    public PlayerController playerController;  // Referencia al script que controla al jugador
   

    void Start()
    {
        // Asociamos comandos de voz con funciones específicas

        actions = new Dictionary<string, System.Action>
{
    // Movimiento hacia adelante
    { "avanzar", MoveForward },
    { "hacia adelante", MoveForward },
    { "vamos hacia adelante", MoveForward },
    { "sigue adelante", MoveForward },
    { "adelante", MoveForward },
    { "go forward", MoveForward },
    { "move forward", MoveForward },
    { "keep going", MoveForward },
    { "forward", MoveForward },
    { "keep moving", MoveForward },
    { "continue forward", MoveForward },

    // Movimiento hacia atrás
    { "hacia atras", MoveBackward },
    { "vamos hacia atras", MoveBackward },
    { "atrás", MoveBackward },
    { "sigue hacia atras", MoveBackward },
    { "go back", MoveBackward },
    { "move back", MoveBackward },
    { "move backward", MoveBackward },
    { "backward", MoveBackward },
    { "back", MoveBackward },

    // Disparo
    { "shoot", Shoot },
    { "dispara", Shoot },
    { "fire", Shoot },

    // Iniciar
    { "play", StartMoving },
    { "start", StartMoving },
    { "comenzar", StartMoving },
    { "iniciar", StartMoving },

    // Detener
    { "stop", StopMoving },
    { "pause", StopMoving },
    { "detente", StopMoving },
    { "pausar", StopMoving },
    { "alto", StopMoving },
    { "parar", StopMoving }
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

    // Función para ejecutar el disparo (activa animación en PlayerController)
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
        if (playerController == null)
        {
            return;
        }
        Vector3 forwardDirection = playerController.transform.forward;
        Vector3 targetPosition = playerController.transform.position + forwardDirection * 3f; // Avanza 3 metros
        playerController.MoveTo(targetPosition);
    }

    public void MoveBackward()
    {
        if (playerController == null)
        {
            return;
        }
        Vector3 backwardDirection = -playerController.transform.forward;
        Vector3 targetPosition = playerController.transform.position + backwardDirection * 3f; // Retrocede 3 metros
        playerController.MoveTo(targetPosition);
    }

}
