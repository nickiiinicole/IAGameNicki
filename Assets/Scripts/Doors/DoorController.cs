using UnityEngine;
using UnityEngine.AI;

public class DoorController : MonoBehaviour
{
    public string keyRequired;
    //public Animator animator;
    private bool isOpen = false;

    public float initialAngle = 0f;
    public float finalAngle = 90f;

    private void Start()
    {
        // Aplica rotación inicial en el eje Y
        Vector3 currentEuler = transform.eulerAngles;
        currentEuler.y = initialAngle;
        transform.eulerAngles = currentEuler;
    }

    private System.Collections.IEnumerator InterpolateY()
    {
        float duration = 1f;
        float elapsed = 0f;

        float startY = initialAngle;
        float endY = finalAngle;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            float currentY = Mathf.Lerp(startY, endY, t);

            Vector3 currentEuler = transform.eulerAngles;
            currentEuler.y = currentY;
            transform.eulerAngles = currentEuler;

            yield return null;
        }

        // Asegura que se quede en el valor final exacto
        Vector3 finalEuler = transform.eulerAngles;
        finalEuler.y = endY;
        transform.eulerAngles = finalEuler;
    }

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
        StartCoroutine(InterpolateY());
        //if (animator != null)
        //{
        //    animator.SetTrigger("open");
        //}

        // Opcional----> desactivar colisión o NavMeshObstacle si quieres que pasen NPCs también
        // Collider col = GetComponent<Collider>();
        // if (col != null)
        // {
        //     col.enabled = false;
        // }
    }
}
