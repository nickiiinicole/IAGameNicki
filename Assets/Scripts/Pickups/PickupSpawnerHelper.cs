using UnityEngine;

public class PickupSpawnerHelper : MonoBehaviour
{
    public PickupSpawner spawner;
    public int arrayPosition = 0;

    private void OnDestroy()
    {
        spawner.NotifyPickUp(arrayPosition);
    }
}
