using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform playerTarget;

    [Header("Movimiento")]
    public float followSpeed = 5f;
    public float maxSpeed = 10f;
    public float stoppingDistance = 0.1f;

    private Vector3 currentVelocity;

    void Update()
    {
        if (playerTarget == null)
            return;

        float distance = Vector3.Distance(transform.position, playerTarget.position);

        if (distance > stoppingDistance)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                playerTarget.position,
                followSpeed * Time.deltaTime
            );
        }
    }
}
