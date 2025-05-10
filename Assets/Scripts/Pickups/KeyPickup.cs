using UnityEngine;
using UnityEngine.UIElements;

public class KeyPickup : MonoBehaviour
{
    public string keyName;
    public GameObject pickupEffect;
    public bool rotate = true;
    public float rotationSpeed = 0.6f;
    public AudioSource audioSource;
    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            if (other.tag.ToLower() != "player")
            {
                return;
            }

            if (!player.keyNames.Contains(keyName))
            {
                player.CollectKey(keyName);
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
