using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickupPrefabs;
    public Transform[] spawnPoints;
    public float timeWindow = 10f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPickup), 0f, timeWindow);
    }

    void SpawnPickup()
    {
        GameObject prefab = pickupPrefabs[Random.Range(0, pickupPrefabs.Length)];
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(prefab, point.position, Quaternion.identity);
    }
}
