using UnityEngine;
using UnityEngine.Audio;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 5;
    public ParticleSystem pickupEffect;
    public bool rotate = true; 
    public float rotationSpeed = 0.5f;
    public AudioSource audioSource;

    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider colliderobject)
    {
        if (colliderobject.tag == "Player")
        {
            PlayerController pc = colliderobject.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.AddAmmo(ammoAmount);

                if (pickupEffect != null)
                {
                    Instantiate(pickupEffect, transform.position, Quaternion.identity);
                }

                if (audioSource != null && audioSource.clip != null)
                {
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                }
                


                Destroy(gameObject);
            }
        }
    }
}
