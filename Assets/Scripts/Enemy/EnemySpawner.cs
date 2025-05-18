using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

/// <summary>
/// Controla la aparición de enemigos desde diferentes puntos en la escena,
/// manteniendo un número máximo de enemigos activos simultáneamente.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración de Spawner")]

    // Puntos de la escena donde pueden aparecer enemigos
    public Transform[] spawnPoints;

    // Prefabs disponibles para generar diferentes tipos de enemigos
    public GameObject[] enemyPrefabs;

    // Tiempo entre cada intento de aparición de enemigos
    public float timeWindow = 5f;

    // Límite de enemigos vivos simultáneamente en la escena
    public int enemiesAmountLimit = 5;

    // Número actual de enemigos vivos
    private int currentEnemyCount = 0;

    /*
    // Estos campos fueron comentados y no se usan actualmente, pero podrían servir para:
    // Control de navegación de los enemigos o su comportamiento
    // public NavMeshAgent agent;
    // public ThirdPersonCharacter characterController;
    // public Transform PlayerTargert;
    */

    /// <summary>
    /// Inicia el ciclo de aparición de enemigos con un intervalo fijo de tiempo.
    /// </summary>
    void Start()
    {
        // Llama repetidamente a SpawnEnemyIfAllowed cada 'timeWindow' segundos
        InvokeRepeating(nameof(SpawnEnemyIfAllowed), 0f, timeWindow);
    }

    /// <summary>
    /// Instancia un enemigo aleatorio si no se ha alcanzado el límite de enemigos activos.
    /// </summary>
    void SpawnEnemyIfAllowed()
    {
        // Si ya hay suficientes enemigos, no hace nada
        if (currentEnemyCount >= enemiesAmountLimit) return;

        // Selecciona un punto de aparición y un tipo de enemigo al azar
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Instancia el enemigo en la escena
        GameObject newEnemy = Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        // Incrementa el contador de enemigos vivos
        currentEnemyCount++;

        // Añade el componente helper que informará cuando el enemigo muera
        EnemySpawnerHelper helper = newEnemy.AddComponent<EnemySpawnerHelper>();
        helper.spawner = this;
    }

    /// <summary>
    /// Llamada por los enemigos al morir para reducir el contador de enemigos vivos.
    /// </summary>
    public void NotifyEnemyDeath()
    {
        currentEnemyCount = Mathf.Max(0, currentEnemyCount - 1);
    }
}
