using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 20;
    public ParticleSystem pickupEffect;

    private void OnTriggerEnter(Collider objectCollider)
    {
        if (objectCollider.tag == "Player")
        {
            PlayerController pc = objectCollider.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.GainHealth(healAmount);

                if (pickupEffect != null)
                    Instantiate(pickupEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}
