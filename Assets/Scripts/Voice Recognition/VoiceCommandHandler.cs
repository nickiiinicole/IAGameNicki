using UnityEngine;
using UnityEngine.Windows.Speech; // Permite el uso de reconocimiento de voz
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Este script permite controlar al jugador mediante comandos de voz.
/// Utiliza un KeywordRecognizer para escuchar frases específicas y ejecutar acciones asociadas
/// </summary>
public class VoiceCommandHandler : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer; // Reconoce palabras/frases clave habladas
    private Dictionary<string, System.Action> actions; // Diccionario que relaciona comandos de voz con acciones del juego

    public PlayerController playerController; // Referencia al controlador del jugador

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
            { "sigue hacia atras boludo", MoveBackward },
            { "retrocede", MoveBackward },
            { "retrocede boludo", MoveBackward },
            { "vete atras", MoveBackward },
            { "vuelta atras", MoveBackward },
            { "go back", MoveBackward },
            { "move back", MoveBackward },
            { "move backward", MoveBackward },
            { "backward", MoveBackward },
            { "back", MoveBackward },

            // Disparo
            { "shoot", Shoot },
            { "dispara", Shoot },
            { "fire", Shoot },

            // Iniciar movimiento
            { "play", StartMoving },
            { "start", StartMoving },
            { "comenzar", StartMoving },
            { "iniciar", StartMoving },

            // Detener movimiento
            { "stop", StopMoving },
            { "pause", StopMoving },
            { "detente", StopMoving },
            { "pausar", StopMoving },
            { "alto", StopMoving },
            { "parar", StopMoving },

            // Girar a la izquierda
            { "gira a la izquierda", TurnLeft },
            { "girar a la izquierda", TurnLeft },
            { "izquierda", TurnLeft },
            { "dobla a la izquierda", TurnLeft },
            { "vuelta a la izquierda", TurnLeft },
            { "hacia la izquierda", TurnLeft },
            { "turn left", TurnLeft },

            // Girar a la derecha
            { "gira a la derecha", TurnRight },
            { "girar a la derecha", TurnRight },
            { "derecha", TurnRight },
            { "dobla a la derecha", TurnRight },
            { "vuelta a la derecha", TurnRight },
            { "hacia la derecha", TurnRight },
            { "turn right", TurnRight }
        };

        // Inicializa el reconocedor con todas las frases clave definidas
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());

        // Asocia la función de callback cuando se reconoce una frase
        keywordRecognizer.OnPhraseRecognized += OnKeywordRecognized;

        // Inicia el reconocimiento de voz
        keywordRecognizer.Start();
    }

    /// <summary>
    /// Llamada automáticamente cuando se reconoce una frase hablada.
    /// </summary>
    void OnKeywordRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword Recognized: " + args.text);

        if (playerController.playerInControl) {
            // Ejecuta la acción correspondiente a la frase reconocida
            actions[args.text]?.Invoke();
        }
    }

    /// <summary>Gira el jugador a la izquierda mediante el PlayerController.</summary>
    void TurnLeft()
    {
        if (playerController != null)
        {
            playerController.TurnLeft();
        }
    }

    /// <summary>Gira el jugador a la derecha mediante el PlayerController.</summary>
    void TurnRight()
    {
        if (playerController != null)
        {
            playerController.TurnRight();
        }
    }

    /// <summary>Activa la animación de disparo en el PlayerController.</summary>
    void Shoot()
    {
        if (playerController != null)
        {
            playerController.TriggerShootAnimation();
        }
    }

    /// <summary>Inicia el movimiento hacia adelante como acción por defecto.</summary>
    void StartMoving()
    {
        Debug.Log("Comenzar movimiento");
        MoveForward(); // Avanza como acción predeterminada
    }

    /// <summary>Detiene cualquier movimiento actual del jugador.</summary>
    void StopMoving()
    {
        Debug.Log("Detener movimiento");
        if (playerController != null)
        {
            playerController.StopMovement();
        }
    }

    /// <summary>Mueve al jugador 5 metros hacia adelante.</summary>
    public void MoveForward()
    {
        Debug.Log("Movimiento hacia adelante");
        if (playerController != null)
        {
            playerController.MoveForward();
        }
    }

    /// <summary>Mueve al jugador 5 metros hacia atrás.</summary>
    public void MoveBackward()
    {
        Debug.Log("Movimiento hacia atras");
        if (playerController != null)
        {
            playerController.MoveBackward();
        }
    }
}
