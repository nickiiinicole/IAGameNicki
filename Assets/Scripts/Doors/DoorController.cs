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

    // �ngulo inicial (cerrada) y final (abierta) en el eje Y
    public float initialAngle = 0f;
    public float finalAngle = 90f;

    // Referencia al obst�culo de navegaci�n (para evitar paso cuando est� cerrada)
    public NavMeshObstacle obstacle;

    // Collider de la puerta (bloquea f�sicamente el paso)
    public BoxCollider boxCollider;

    /// <summary>
    /// Inicializa la rotaci�n de la puerta y asegura que el obst�culo est� activo.
    /// </summary>
    private void Start()
    {
        // Se configura la rotaci�n inicial en el eje Y
        Vector3 currentEuler = transform.eulerAngles;
        currentEuler.y = initialAngle;
        transform.localRotation = Quaternion.Euler(currentEuler);

        // Activa el obst�culo de navegaci�n si est� definido
        if (obstacle != null)
        {
            obstacle.enabled = true;
        }
    }

    /// <summary>
    /// Corrutina que rota suavemente la puerta desde el �ngulo inicial al final en 1 segundo.
    /// Tambi�n desactiva el NavMeshObstacle al finalizar la apertura.
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

        // Desactiva el obst�culo de navegaci�n al abrir la puerta
        if (obstacle != null)
        {
            obstacle.enabled = false;
        }
    }

    /// <summary>
    /// Detecta si un jugador entra al trigger de la puerta.
    /// Si tiene la llave correcta y la puerta no est� abierta, se abre.
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

        // Si el jugador tiene la llave y la puerta est� cerrada, la abre
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
    /// L�gica para abrir la puerta: desactiva el collider, inicia la rotaci�n e indica que est� abierta.
    /// </summary>
    private void OpenDoor()
    {
        boxCollider.enabled = false; // Se desactiva el collider f�sico
        isOpen = true;               // Marca la puerta como abierta
        StartCoroutine(InterpolateY()); // Comienza la animaci�n de apertura
    }
}
