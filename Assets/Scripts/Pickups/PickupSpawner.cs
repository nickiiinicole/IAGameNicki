using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class SpawnPointWithStatus
{
    public Transform point;
    public bool used = false;
}

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickupPrefabs;
    [Header("Puntos de aparición")]
    public SpawnPointWithStatus[] spawnPoints;
    public float timeWindow = 10f;

    private System.Random rng = new System.Random();

    void Start()
    {
        InvokeRepeating(nameof(SpawnPickup), 0f, timeWindow);
    }

    void SpawnPickup()
    {
        GameObject prefab = pickupPrefabs[rng.Next(0, pickupPrefabs.Length)];
        int randomPointIndex = rng.Next(0, spawnPoints.Length);
        SpawnPointWithStatus temporalRandomSpawnPoint = spawnPoints[randomPointIndex];

        if (!temporalRandomSpawnPoint.used)
        {
            Transform point = temporalRandomSpawnPoint.point;
            GameObject temporalNewObject = Instantiate(prefab, point.position, Quaternion.identity);
            temporalRandomSpawnPoint.used = true;
            PickupSpawnerHelper helper = temporalNewObject.AddComponent<PickupSpawnerHelper>();
            helper.spawner = this;
            helper.arrayPosition = randomPointIndex;
        }
    }

    public void NotifyPickUp(int arrayPosition)
    {
        spawnPoints[arrayPosition].used = false;
    }
}
