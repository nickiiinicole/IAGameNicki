using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    [SerializeField]
    private float health;

    void Start()
    {
        agent.updateRotation = false;
    }

    public void TakeDamage(float damageAmmount) {
        health = health - damageAmmount;
        if (health <= 0) {
            health = 0;
            // Animar muerte y quitar el control de voz al user
        }
    }

    void Update()
    {
        //agent.SetDestination(PlayerTargert.position);

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}