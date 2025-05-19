using System.ComponentModel;
using Unity.Collections;
using Unity.VisualScripting;
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
    private AudioSource audioSource;
    private float growlCooldown;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        agent.updateRotation = false;

        // Busca el primer GameObject en la escena con el tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            //Debug.Log("Jugador encontrado: " + playerObject.name);
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
        if (Time.time > growlCooldown)
        {
            PlayGrowl();
            growlCooldown = Time.time + Random.Range(3f, 8f); // el próximo gruñido entre 4 y 8 segundos
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
    public void PlayGrowl()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play(); 
        }
    }
    public void TakeDamage(float damageAmount)
    {
        if (isDead)
        {
            return;
        }

        health -= damageAmount;
        Debug.Log("Daño a enemigo, restante"+ health);

        if (health <= 0)
        {
            health = 0;
            animator.SetTrigger("dead");
            isDead = true;
            Destroy(gameObject,5);
            return;
        }

        animator.SetTrigger("isHurting");
    }
}