using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controlador de puertas que se abren si el jugador posee la llave correcta.
/// </summary>
public class DoorController : MonoBehaviour
{
    // Nombre de la llave requerida para abrir la puerta
    public string keyRequired;

    // Estado actual de la puerta
    private bool isOpen = false;

    // Ángulo inicial (cerrada) y final (abierta) en el eje Y
    public float initialAngle = 0f;
    public float finalAngle = 90f;

    // Referencia al obstáculo de navegación (para evitar paso cuando está cerrada)
    public NavMeshObstacle obstacle;

    // Collider de la puerta (bloquea físicamente el paso)
    public BoxCollider boxCollider;

    /// <summary>
    /// Inicializa la rotación de la puerta y asegura que el obstáculo esté activo.
    /// </summary>
    private void Start()
    {
        // Se configura la rotación inicial en el eje Y
        Vector3 currentEuler = transform.eulerAngles;
        currentEuler.y = initialAngle;
        transform.localRotation = Quaternion.Euler(currentEuler);

        // Activa el obstáculo de navegación si está definido
        if (obstacle != null)
        {
            obstacle.enabled = true;
        }
    }

    /// <summary>
    /// Corrutina que rota suavemente la puerta desde el ángulo inicial al final en 1 segundo.
    /// También desactiva el NavMeshObstacle al finalizar la apertura.
    /// </summary>
    private System.Collections.IEnumerator InterpolateY()
    {
        float duration = 1f;
        float elapsed = 0f;

        Quaternion startRotation = Quaternion.Euler(0f, initialAngle, 0f);
        Quaternion endRotation = Quaternion.Euler(0f, finalAngle, 0f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, t);

            yield return null; // Espera al siguiente frame
        }

        transform.localRotation = endRotation;

        // Desactiva el obstáculo de navegación al abrir la puerta
        if (obstacle != null)
        {
            obstacle.enabled = false;
        }
    }

    /// <summary>
    /// Detecta si un jugador entra al trigger de la puerta.
    /// Si tiene la llave correcta y la puerta no está abierta, se abre.
    /// </summary>
    /// <param name="other">Collider que entra en contacto con la puerta.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Asegura que el collider sea el jugador
        if (other.tag.ToLower() != "player")
        {
            return;
        }

        PlayerController player = other.GetComponent<PlayerController>();

        // Si el jugador tiene la llave y la puerta está cerrada, la abre
        if (player != null && player.keyNames.Contains(keyRequired) && !isOpen)
        {
            OpenDoor();
        }
        // Si no tiene la llave, se notifica en consola
        else if (player != null && !player.keyNames.Contains(keyRequired))
        {
            Debug.Log("Te falta la llave: " + keyRequired);
        }
    }

    /// <summary>
    /// Lógica para abrir la puerta: desactiva el collider, inicia la rotación e indica que está abierta.
    /// </summary>
    private void OpenDoor()
    {
        boxCollider.enabled = false; // Se desactiva el collider físico
        isOpen = true;               // Marca la puerta como abierta
        StartCoroutine(InterpolateY()); // Comienza la animación de apertura
    }
}
