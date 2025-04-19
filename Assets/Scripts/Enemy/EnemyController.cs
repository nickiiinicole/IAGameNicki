using System.ComponentModel;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public ThirdPersonCharacter characterController;
    public Transform PlayerTargert;
    [SerializeField] private float health = 100;
    [SerializeField] Animator animator;
    [SerializeField] bool isDead = false;

    void Start()
    {
        agent.updateRotation = false;

        // Busca el primer GameObject en la escena con el tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            Debug.Log("Jugador encontrado: " + playerObject.name);
            PlayerTargert = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        agent.SetDestination(PlayerTargert.position);

        if (characterController == null)
        {
            return;
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            characterController.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            characterController.Move(Vector3.zero, false, false);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (isDead)
        {
            return;
        }

        health -= damageAmount;

        if (health <= 0)
        {
            health = 0;
            animator.SetTrigger("dead");
            isDead = true;
            return;
        }

        animator.SetTrigger("isHurting");
    }
}