using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public string keyName;
    public ParticleSystem pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.CollectKey(keyName);

                if (pickupEffect != null)
                    Instantiate(pickupEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}
