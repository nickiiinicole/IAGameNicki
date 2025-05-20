using UnityEngine;

/// <summary>
/// Hace que el objeto siga a un objetivo (playerTarget) suavemente usando interpolaci�n.
/// </summary>
public class PlayerFollow : MonoBehaviour
{
    [Header("Target")]
    /// <summary>
    /// Transform del objetivo que este objeto debe seguir (usualmente el jugador).
    /// </summary>
    public Transform playerTarget;

    [Header("Movimiento")]
    /// <summary>
    /// Velocidad a la que el objeto sigue al objetivo.
    /// </summary>
    public float followSpeed = 5f;

    /// <summary>
    /// Velocidad m�xima permitida (no usada en el c�digo actual, pero podr�a ser para limitar).
    /// </summary>
    public float maxSpeed = 10f;

    /// <summary>
    /// Distancia m�nima para detener el seguimiento y evitar que el objeto "oscile" cerca del objetivo.
    /// </summary>
    public float stoppingDistance = 0.1f;

    private Vector3 currentVelocity; // Variable reservada para seguimiento con SmoothDamp (no usada aqu�)

    /// <summary>
    /// Actualiza la posici�n del objeto cada frame para que se acerque al objetivo con Lerp.
    /// </summary>
    void Update()
    {
        // Si no hay objetivo asignado, salir sin hacer nada
        if (playerTarget == null)
            return;

        // Calcula la distancia actual entre este objeto y el objetivo
        float distance = Vector3.Distance(transform.position, playerTarget.position);

        // Si la distancia es mayor que la distancia de parada, mueve el objeto hacia el objetivo
        if (distance > stoppingDistance)
        {
            // Interpola suavemente la posici�n actual hacia la posici�n del objetivo, 
            // usando followSpeed para controlar la rapidez del movimiento
            transform.position = Vector3.Lerp(
                transform.position,
                playerTarget.position,
                followSpeed * Time.deltaTime
            );
        }
    }
}
