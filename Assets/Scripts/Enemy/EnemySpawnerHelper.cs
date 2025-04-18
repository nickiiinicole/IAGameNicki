using UnityEngine;

public class EnemySpawnerHelper : MonoBehaviour
{
    public EnemySpawner spawner;
    private void OnDestroy()
    {
        spawner.NotifyEnemyDeath();
    }
}
