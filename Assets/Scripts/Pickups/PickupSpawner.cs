using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Clase que representa un punto de aparición (spawn) junto con un estado
/// que indica si ya fue usado para generar un objeto.
/// </summary>
[Serializable]
public class SpawnPointWithStatus
{
    /// <summary>
    /// Transform que indica la posición del punto de aparición.
    /// </summary>
    public Transform point;

    /// <summary>
    /// Indica si el punto ya fue usado para crear un pickup.
    /// </summary>
    public bool used = false;
}

/// <summary>
/// Controla la aparición periódica de objetos tipo pickup en puntos definidos.
/// </summary>
public class PickupSpawner : MonoBehaviour
{
    /// <summary>
    /// Array de prefabs de pickups que pueden generarse.
    /// </summary>
    public GameObject[] pickupPrefabs;

    [Header("Puntos de aparición")]
    /// <summary>
    /// Array de puntos de spawn con su estado de uso.
    /// </summary>
    public SpawnPointWithStatus[] spawnPoints;

    /// <summary>
    /// Tiempo en segundos entre cada intento de generar un pickup.
    /// </summary>
    public float timeWindow = 10f;

    /// <summary>
    /// Generador de números aleatorios para seleccionar pickups y puntos.
    /// </summary>
    private System.Random rng = new System.Random();

    /// <summary>
    /// Método llamado al iniciar el script.
    /// Programa la ejecución repetida de SpawnPickup cada 'timeWindow' segundos.
    /// </summary>
    void Start()
    {
        InvokeRepeating(nameof(SpawnPickup), 0f, timeWindow);
    }

    /// <summary>
    /// Método que genera un pickup en un punto aleatorio no usado.
    /// </summary>
    void SpawnPickup()
    {
        // Selecciona aleatoriamente un prefab de pickup
        GameObject prefab = pickupPrefabs[rng.Next(0, pickupPrefabs.Length)];

        // Selecciona aleatoriamente un punto de spawn
        int randomPointIndex = rng.Next(0, spawnPoints.Length);
        SpawnPointWithStatus temporalRandomSpawnPoint = spawnPoints[randomPointIndex];

        // Solo genera el pickup si el punto no ha sido usado
        if (!temporalRandomSpawnPoint.used)
        {
            Transform point = temporalRandomSpawnPoint.point;

            // Instancia el pickup en la posición del punto seleccionado
            GameObject temporalNewObject = Instantiate(prefab, point.position, Quaternion.identity);

            // Marca el punto como usado para evitar que se use simultáneamente
            temporalRandomSpawnPoint.used = true;

            // Añade un helper para gestionar la notificación cuando el pickup sea recogido o destruido
            PickupSpawnerHelper helper = temporalNewObject.AddComponent<PickupSpawnerHelper>();

            // Le pasa una referencia a este spawner y la posición del punto en el array
            helper.spawner = this;
            helper.arrayPosition = randomPointIndex;
        }
    }

    /// <summary>
    /// Método público llamado por los pickups para notificar que el punto está libre nuevamente.
    /// </summary>
    /// <param name="arrayPosition">Índice del punto en el array de spawnPoints que queda libre.</param>
    public void NotifyPickUp(int arrayPosition)
    {
        spawnPoints[arrayPosition].used = false;
    }
}
