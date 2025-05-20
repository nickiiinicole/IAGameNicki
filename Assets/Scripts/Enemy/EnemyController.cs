using System.ComponentModel;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

/// <summary>
/// Controlador de enemigos. Gestiona su movimiento hacia el jugador,
/// los sonidos de gru�ido, animaciones, y la recepci�n de da�o.
/// </summary>
public class EnemyController : MonoBehaviour
{
    // Referencias p�blicas configurables desde el Inspector
    public NavMeshAgent agent;  // Agente de navegaci�n
    public ThirdPersonCharacter characterController;  // Controlador de movimiento visual
    public Transform PlayerTargert;  // Objetivo (el jugador)

    [SerializeField] private float health = 100;  // Vida del enemigo
    [SerializeField] Animator animator;  // Referencia al Animator del enemigo
    [SerializeField] bool isDead = false;  // Estado de muerte

    private AudioSource audioSource;  // Fuente de audio local
    private float growlCooldown;  // Tiempo para limitar gru�idos

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Evita que el agente rote autom�ticamente
        agent.updateRotation = false;

        // Busca el jugador autom�ticamente por tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            PlayerTargert = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No se encontr� ning�n objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        // Mueve al enemigo hacia la posici�n del jugador
        agent.SetDestination(PlayerTargert.position);

        if (characterController == null)
            return;

        // Controla el sonido de gru�ido con tiempo aleatorio entre cada reproducci�n
        if (Time.time > growlCooldown)
        {
            PlayGrowl();
            growlCooldown = Time.time + Random.Range(3f, 8f); // Pr�ximo gru�ido en 3�8 s
        }

        // Movimiento animado hacia el jugador si no ha llegado a su destino
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            characterController.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            // Se detiene si ha llegado al jugador
            characterController.Move(Vector3.zero, false, false);
        }
    }

    /// <summary>
    /// Reproduce el gru�ido del enemigo si no hay otro sonido activo.
    /// </summary>
    public void PlayGrowl()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Recibe da�o externo y gestiona la vida, animaciones y destrucci�n.
    /// </summary>
    /// <param name="damageAmount">Cantidad de da�o recibida</param>
    public void TakeDamage(float damageAmount)
    {
        if (isDead) return;

        health -= damageAmount;
        Debug.Log("Da�o a enemigo, restante: " + health);

        if (health <= 0)
        {
            health = 0;
            isDead = true;

            // Ejecuta animaci�n de muerte
            animator.SetTrigger("dead");

            // Elimina al enemigo tras 5 segundos
            Destroy(gameObject, 5);
            return;
        }

        // Ejecuta animaci�n de da�o
        animator.SetTrigger("isHurting");
    }
}
