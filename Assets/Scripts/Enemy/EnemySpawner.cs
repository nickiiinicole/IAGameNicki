using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración de Spawner")]
    public Transform[] spawnPoints;                     // Puntos posibles de aparición
    public GameObject[] enemyPrefabs;                   // Prefabs de enemigos a instanciar
    public float timeWindow = 5f;                       // Tiempo entre spawns
    public int enemiesAmountLimit = 5;                  // Máximo de enemigos simultáneos

    private int currentEnemyCount = 0;                  // Contador de enemigos vivos
    
    //public NavMeshAgent agent;
    //public ThirdPersonCharacter characterController;
    //public Transform PlayerTargert;

    void Start()
    {
        // Comienza el ciclo de spawn
        InvokeRepeating(nameof(SpawnEnemyIfAllowed), 0f, timeWindow);
    }

    void SpawnEnemyIfAllowed()
    {
        if (currentEnemyCount >= enemiesAmountLimit) return;

        // Seleccionamos aleatoriamente un spawn point y un prefab
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Instanciamos el enemigo
        GameObject newEnemy = Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        // Aumentamos el contador
        currentEnemyCount++;

        // Aseguramos que el enemigo tenga el script para notificar al morir
        EnemySpawnerHelper helper = newEnemy.AddComponent<EnemySpawnerHelper>();

        helper.spawner = this;
    }

    // Función pública para reducir el contador cuando un enemigo muere
    public void NotifyEnemyDeath
        ()
    {
        currentEnemyCount = Mathf.Max(0, currentEnemyCount - 1);
    }
}
