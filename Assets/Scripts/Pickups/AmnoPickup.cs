using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 5;
    public ParticleSystem pickupEffect;

    private void OnTriggerEnter(Collider colliderobject)
    {
        if (colliderobject.tag == "Player")
        {
            PlayerController pc = colliderobject.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.AddAmmo(ammoAmount);

                if (pickupEffect != null)
                    Instantiate(pickupEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}
