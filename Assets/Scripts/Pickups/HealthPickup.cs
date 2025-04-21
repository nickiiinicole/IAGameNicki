using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 20;
    public ParticleSystem pickupEffect;
    public bool rotate = true;
    public float rotationSpeed = 0.5f;
    public AudioSource audioSource;
    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider objectCollider)
    {
        if (objectCollider.tag == "Player")
        {
            PlayerController pc = objectCollider.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.GainHealth(healAmount);

                if (pickupEffect != null)
                { 
                    Instantiate(pickupEffect, transform.position, Quaternion.identity); 
                }

                if (audioSource)
                {
                    audioSource.Play();
                }

                Destroy(gameObject);
            }
        }
    }
}
