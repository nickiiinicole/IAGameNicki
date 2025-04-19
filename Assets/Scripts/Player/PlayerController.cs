using System.Collections.Generic;
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
    public NavMeshAgent agent;
    public ThirdPersonCharacter character; // Controlador de animaciones y movimiento
    public GameObject bulletPrefab;
    public Transform firePoint;
    [Header("Salud")]
    [SerializeField] private float health;
    [SerializeField] private int ammo;
    [SerializeField] private float voiceMoveDistance = 5f;
    [SerializeField] Animator animator;
    public List<string> keyNames = new List<string>();
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private int currentAmmo = 10;


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
        Debug.Log("TakeDamage llamado");
        health -= damageAmount;

        if (health <= 0)
        {
            health = 0;
            animator.SetTrigger("deathTrigger");
        }
        animator.SetTrigger("isHurting");
    }
    // <summary>
    // Activa la animación de disparo del player
    // </summary>

    public void TriggerShootAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("isShooting");
            Debug.Log("Disparo activado por voz");
            Shoot();
        }
    }

    public void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            if (ammo > 0)
            {
                ammo--;
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
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
    /// <summary>
    /// Recolectar llave.
    /// </summary>
    /// <param name="keyName"></param>

    public void CollectKey(string keyName)
    {
        if (!keyNames.Contains(keyName))
        {
            keyNames.Add(keyName);
            Debug.Log("Llave obtenida: " + keyName);
        }
    }


    public void GainHealth(int amount)
    {
        health = Mathf.Min(maxHealth, health + amount);
        Debug.Log("Salud aumentada. Salud actual: " + health);
    }

    public void AddAmmo(int amount)
    {
        currentAmmo += amount;
        Debug.Log("Munición añadida. Total actual: " + currentAmmo);
    }
}
