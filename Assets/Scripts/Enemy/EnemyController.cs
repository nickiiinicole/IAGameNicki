using System.ComponentModel;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

/// <summary>
/// Controlador de enemigos. Gestiona su movimiento hacia el jugador,
/// los sonidos de gruñido, animaciones, y la recepción de daño.
/// </summary>
public class EnemyController : MonoBehaviour
{
    // Referencias públicas configurables desde el Inspector
    public NavMeshAgent agent;  // Agente de navegación
    public ThirdPersonCharacter characterController;  // Controlador de movimiento visual
    public Transform PlayerTargert;  // Objetivo (el jugador)

    [SerializeField] private float health = 100;  // Vida del enemigo
    [SerializeField] Animator animator;  // Referencia al Animator del enemigo
    [SerializeField] bool isDead = false;  // Estado de muerte

    private AudioSource audioSource;  // Fuente de audio local
    private float growlCooldown;  // Tiempo para limitar gruñidos

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Evita que el agente rote automáticamente
        agent.updateRotation = false;

        // Busca el jugador automáticamente por tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            PlayerTargert = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        // Mueve al enemigo hacia la posición del jugador
        agent.SetDestination(PlayerTargert.position);

        if (characterController == null)
            return;

        // Controla el sonido de gruñido con tiempo aleatorio entre cada reproducción
        if (Time.time > growlCooldown)
        {
            PlayGrowl();
            growlCooldown = Time.time + Random.Range(3f, 8f); // Próximo gruñido en 3–8 s
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
    /// Reproduce el gruñido del enemigo si no hay otro sonido activo.
    /// </summary>
    public void PlayGrowl()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Recibe daño externo y gestiona la vida, animaciones y destrucción.
    /// </summary>
    /// <param name="damageAmount">Cantidad de daño recibida</param>
    public void TakeDamage(float damageAmount)
    {
        if (isDead) return;

        health -= damageAmount;
        Debug.Log("Daño a enemigo, restante: " + health);

        if (health <= 0)
        {
            health = 0;
            isDead = true;

            // Ejecuta animación de muerte
            animator.SetTrigger("dead");

            // Elimina al enemigo tras 5 segundos
            Destroy(gameObject, 5);
            return;
        }

        // Ejecuta animación de daño
        animator.SetTrigger("isHurting");
    }
}
