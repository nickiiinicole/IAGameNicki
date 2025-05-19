using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 15;
    public ParticleSystem pickupEffect;
    public bool rotate = true;
    public float rotationSpeed = 0.5f;
    public AudioSource audioSource;

    private PickupSpawnerHelper helper;

    void Start()
    {
        helper = GetComponent<PickupSpawnerHelper>();
    }

    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc == null)
            {
                pc = other.GetComponentInParent<PlayerController>(); // por si está en un hijo
            }

            if (pc != null)
            {
                pc.GainHealth(healAmount);

                if (pickupEffect != null)
                    Instantiate(pickupEffect, transform.position, Quaternion.identity);

                if (audioSource != null && audioSource.clip != null)
                {
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                }

                if (helper != null && helper.spawner != null)
                {
                    helper.spawner.NotifyPickUp(helper.arrayPosition);
                }

                Destroy(gameObject);
            }
        }
    }
}
