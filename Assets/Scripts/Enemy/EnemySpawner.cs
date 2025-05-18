using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

/// <summary>
/// Controla la aparici�n de enemigos desde diferentes puntos en la escena,
/// manteniendo un n�mero m�ximo de enemigos activos simult�neamente.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [Header("Configuraci�n de Spawner")]

    // Puntos de la escena donde pueden aparecer enemigos
    public Transform[] spawnPoints;

    // Prefabs disponibles para generar diferentes tipos de enemigos
    public GameObject[] enemyPrefabs;

    // Tiempo entre cada intento de aparici�n de enemigos
    public float timeWindow = 5f;

    // L�mite de enemigos vivos simult�neamente en la escena
    public int enemiesAmountLimit = 5;

    // N�mero actual de enemigos vivos
    private int currentEnemyCount = 0;

    /*
    // Estos campos fueron comentados y no se usan actualmente, pero podr�an servir para:
    // Control de navegaci�n de los enemigos o su comportamiento
    // public NavMeshAgent agent;
    // public ThirdPersonCharacter characterController;
    // public Transform PlayerTargert;
    */

    /// <summary>
    /// Inicia el ciclo de aparici�n de enemigos con un intervalo fijo de tiempo.
    /// </summary>
    void Start()
    {
        // Llama repetidamente a SpawnEnemyIfAllowed cada 'timeWindow' segundos
        InvokeRepeating(nameof(SpawnEnemyIfAllowed), 0f, timeWindow);
    }

    /// <summary>
    /// Instancia un enemigo aleatorio si no se ha alcanzado el l�mite de enemigos activos.
    /// </summary>
    void SpawnEnemyIfAllowed()
    {
        // Si ya hay suficientes enemigos, no hace nada
        if (currentEnemyCount >= enemiesAmountLimit) return;

        // Selecciona un punto de aparici�n y un tipo de enemigo al azar
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Instancia el enemigo en la escena
        GameObject newEnemy = Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        // Incrementa el contador de enemigos vivos
        currentEnemyCount++;

        // A�ade el componente helper que informar� cuando el enemigo muera
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
