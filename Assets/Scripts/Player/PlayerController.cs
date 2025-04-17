using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

/// <summary>
/// Controlador del jugador que usa NavMeshAgent para navegar
/// y ThirdPersonCharacter para animaciones y movimiento fluido.
/// Ahora incluye funciones p�blicas para ser controlado por comandos de voz.
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
        // Importante para evitar que el NavMesh gire autom�ticamente (lo controla el personaje)
        agent.updateRotation = false;
    }

    void Update()
    {
        // Movimiento autom�tico hacia el destino asignado por el agente
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
    /// L�gica de da�o al jugador.
    /// </summary>
    /// <param name="damageAmount">Cantidad de da�o a aplicar</param>
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            health = 0;
            // TODO: Animaci�n de muerte si la tienes
            m_Animator.SetTrigger("isHurting"); // Puedes cambiar esto por un trigger de muerte si lo tienes
        }
    }
    // <summary>
    // Activa la animaci�n de disparo del player
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
    /// Mueve al jugador hacia una posici�n objetivo.
    /// Esta funci�n puede llamarse desde comandos de voz o cualquier otro sistema externo.
    /// </summary>
    /// <param name="target">Transform que representa el punto al que se mover�</param>
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
    /// Mueve al jugador hacia adelante una distancia predeterminada desde su posici�n actual.
    /// Ideal para comandos de voz como "avanzar" o "play".
    /// </summary>
    public void MoveForward()
    {
        Vector3 forwardPosition = transform.position + transform.forward * voiceMoveDistance;
        agent.SetDestination(forwardPosition);
    }

    /// <summary>
    /// Mueve al jugador hacia atr�s una distancia predeterminada desde su posici�n actual.
    /// Ideal para comandos como "atr�s" o "retroceder".
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
    /// Puede usarse para reanudar movimiento o como sin�nimo de "play".
    /// Aqu� lo tratamos como un alias de MoveForward().
    /// </summary>
    public void StartMoving()
    {
        MoveForward(); // Puedes reemplazar por una l�gica diferente si quieres
    }
    public void MoveTo(Vector3 position)
    {
        if (agent != null && agent.isOnNavMesh)
        {
            agent.SetDestination(position);
        }
    }

}
