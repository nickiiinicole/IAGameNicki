using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

/// <summary>
/// Controlador del jugador que usa NavMeshAgent para navegar
/// y ThirdPersonCharacter para animaciones y movimiento fluido.
/// Ahora incluye funciones públicas para ser controlado por comandos de voz.
/// </summary>
public class PlayerController : MonoBehaviour
{

    [Header("Componentes")]
    public NavMeshAgent agent; // Agente que se mueve por el NavMesh
    public ThirdPersonCharacter character; // Controlador de animaciones y movimiento
    public GameObject bulletPrefab;
    public Transform firePoint;
    [Header("Salud")]
    [SerializeField] private float health;
    [SerializeField] private float voiceMoveDistance = 5f;
    [SerializeField] Animator m_Animator;

    void Start()
    {
        // Importante para evitar que el NavMesh gire automáticamente (lo controla el personaje)
        agent.updateRotation = false;
    }

    void Update()
    {
        // Movimiento automático hacia el destino asignado por el agente
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }

    /// <summary>
    /// Lógica de daño al jugador.
    /// </summary>
    /// <param name="damageAmount">Cantidad de daño a aplicar</param>
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            health = 0;
            // TODO: Animación de muerte si la tienes
            m_Animator.SetTrigger("isHurting"); // Puedes cambiar esto por un trigger de muerte si lo tienes
        }
    }
    // <summary>
    // Activa la animación de disparo del player
    // </summary>

    public void TriggerShootAnimation()
    {
        if (m_Animator != null)
        {
            m_Animator.SetTrigger("isShooting");
            Debug.Log("Disparo activado por voz");
            Shoot();
        }
    }

    public void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    /// <summary>
    /// Mueve al jugador hacia una posición objetivo.
    /// Esta función puede llamarse desde comandos de voz o cualquier otro sistema externo.
    /// </summary>
    /// <param name="target">Transform que representa el punto al que se moverá</param>
    public void MoveToPosition(Transform target)
    {
        if (agent != null && target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    /// <summary>
    /// Detiene completamente el movimiento del jugador.
    /// Ideal para el comando de voz "stop".
    /// </summary>
    public void Stop()
    {
        if (agent != null)
        {
            agent.ResetPath(); // Borra el destino actual
            agent.velocity = Vector3.zero; // Detiene el movimiento
        }
    }
    /// <summary>
    /// Mueve al jugador hacia adelante una distancia predeterminada desde su posición actual.
    /// Ideal para comandos de voz como "avanzar" o "play".
    /// </summary>
    public void MoveForward()
    {
        Vector3 forwardPosition = transform.position + transform.forward * voiceMoveDistance;
        agent.SetDestination(forwardPosition);
    }

    /// <summary>
    /// Mueve al jugador hacia atrás una distancia predeterminada desde su posición actual.
    /// Ideal para comandos como "atrás" o "retroceder".
    /// </summary>
    public void MoveBackward()
    {
        Vector3 backwardPosition = transform.position - transform.forward * voiceMoveDistance;
        agent.SetDestination(backwardPosition);
    }

    /// <summary>
    /// Detiene al jugador inmediatamente.
    /// </summary>
    public void StopMovement()
    {
        agent.ResetPath();
        agent.velocity = Vector3.zero;
    }

    /// <summary>
    /// Puede usarse para reanudar movimiento o como sinónimo de "play".
    /// Aquí lo tratamos como un alias de MoveForward().
    /// </summary>
    public void StartMoving()
    {
        MoveForward(); // Puedes reemplazar por una lógica diferente si quieres
    }
    public void MoveTo(Vector3 position)
    {
        if (agent != null && agent.isOnNavMesh)
        {
            agent.SetDestination(position);
        }
    }

}
