using System.Collections.Generic;
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
    // Activa la animaci�n de disparo del player
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
        Debug.Log("Munici�n a�adida. Total actual: " + currentAmmo);
    }
}
