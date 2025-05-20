using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Trigger que detecta cuando el jugador entra en una zona específica,
/// y dispara eventos personalizados configurables desde el Inspector.
/// </summary>
public class ReactionTrigger : MonoBehaviour
{
    [Header("Eventos que se ejecutan al paso del jugador")]
    // Evento Unity que se invoca cuando el jugador entra en el trigger
    public UnityEvent onWin;

    /// <summary>
    /// Método llamado automáticamente por Unity cuando un collider entra en este trigger.
    /// Verifica si el objeto que entra tiene el tag "Player" y en ese caso invoca el evento.
    /// </summary>
    /// <param name="other">Collider que entra en el trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba que el objeto que colisiona es el jugador
        if (other.transform.tag == "Player")
        {
            // Invoca el evento onWin, si tiene suscriptores
            onWin?.Invoke();
        }
    }
}
