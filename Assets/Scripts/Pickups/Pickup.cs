using UnityEngine;

public enum PickupType { Health, Ammo }

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int amount = 10;
    public ParticleSystem pickupEffect;

    private void OnTriggerEnter(Collider collisionObject)
    {
        if (collisionObject.gameObject.tag == "Player")
        {
            PlayerController player = collisionObject.GetComponent<PlayerController>();
            if (player != null)
            {
                if (type == PickupType.Health)
                    player.GainHealth(amount);
                else if (type == PickupType.Ammo)
                    player.AddAmmo(amount);

                if (pickupEffect != null)
                    Instantiate(pickupEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}
