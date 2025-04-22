using UnityEngine;
using UnityEngine.AI;

public class DoorController : MonoBehaviour
{
    public string keyRequired;
    // creo una animacion para abriiir la puerta???
    public Animator animator;
    private bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && player.keyNames.Contains(keyRequired) && !isOpen)
        {
            OpenDoor();
        }
        else if (player != null && !player.keyNames.Contains(keyRequired))
        {
            Debug.Log("Te falta la llave: " + keyRequired);
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        if (animator != null)
        {
            animator.SetTrigger("open");
        }

        // Opcional: desactivar colisión o NavMeshObstacle si quieres que pasen NPCs también
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }
    }
}
