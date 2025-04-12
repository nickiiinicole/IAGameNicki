using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public ThirdPersonCharacter characterController;
    public Transform PlayerTargert;

    void Start()
    {
        agent.updateRotation = false;
    }

    void Update()
    {
        agent.SetDestination(PlayerTargert.position);

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            characterController.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            characterController.Move(Vector3.zero, false, false);
        }

    }
}