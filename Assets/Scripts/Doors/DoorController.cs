using UnityEngine;
using UnityEngine.AI;

public class DoorController : MonoBehaviour
{
    public string keyRequired;
    private bool isOpen = false;

    public float initialAngle = 0f;
    public float finalAngle = 90f;
    public NavMeshObstacle obstacle;
    public BoxCollider boxCollider;

    private void Start()
    {
        // rotacion inicial en eje y
        Vector3 currentEuler = transform.eulerAngles;
        currentEuler.y = initialAngle;
        transform.localRotation.SetEulerAngles(currentEuler);

        if (obstacle != null)
        {
            obstacle.enabled = true; //me aseguro de que este activo el navmeshObstacle
        }
    }

    private System.Collections.IEnumerator InterpolateY()
    {
        float duration = 1f;
        float elapsed = 0f;

        Quaternion startRotation = Quaternion.Euler(0f, initialAngle, 0f);
        Quaternion endRotation = Quaternion.Euler(0f, finalAngle, 0f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, t);

            yield return null;
        }

        transform.localRotation = endRotation;

        if (obstacle != null)
        {
            obstacle.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (other.tag.ToLower() != "player"){
            return; 
        }
        if (player != null && player.keyNames.Contains(keyRequired) && !isOpen)
        {
            print("4");
            OpenDoor();
        }
        else if (player != null && !player.keyNames.Contains(keyRequired))
        {
            print("5");
            Debug.Log("Te falta la llave: " + keyRequired);
        }
    }

    private void OpenDoor()
    {
        boxCollider.enabled = false;
        isOpen = true;
        StartCoroutine(InterpolateY());
    }
}
