using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

/// <summary>
/// Este script controla al jugador usando un NavMeshAgent para navegación
/// y ThirdPersonCharacter para animaciones suaves.
/// Incluye funciones que pueden ser llamadas por comandos de voz o sistemas externos.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Componentes")]
    public NavMeshAgent agent; 
    public ThirdPersonCharacter character; 
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

    public MainMenuController mainMenuController;
    public bool playerInControl = false;


    void Start()
    {
        // Evita que el agente gire automáticamente (lo maneja el personaje con animaciones)
        agent.updateRotation = false;
    }

    void Update()
    {
        // Si el agente tiene una ruta y aún no ha llegado al destino
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            // Si llegó al destino, lo detenemos
            character.Move(Vector3.zero, false, false);
        }
    }

    /// <summary>
    /// Llama a esta función cuando el jugador reciba daño.
    /// Disminuye la salud y activa la animación correspondiente.
    /// </summary>
    public void TakeDamage(float damageAmount)
    {
        Debug.Log("TakeDamage llamado");
        health -= damageAmount;

        if (health <= 0)
        {
            health = 0;
            animator.SetTrigger("deathTrigger"); // Activa animación de muerte
            mainMenuController.LostGame();
        }
        animator.SetTrigger("isHurting"); // Activa animación de daño
    }



    /// <summary>
    /// Activa animación de disparo y crea la bala.
    /// </summary>
    public void TriggerShootAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("isShooting");
            Debug.Log("Disparo activado por voz");
            Shoot();
        }
    }

    /// <summary>
    /// Dispara una bala si hay munición disponible.
    /// </summary>
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
    /// Mueve al jugador hacia una posición indicada.
    /// </summary>
    public void MoveToPosition(Transform target)
    {
        if (agent != null && target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    /// <summary>
    /// Detiene el movimiento actual del jugador.
    /// </summary>
    public void Stop()
    {
        if (agent != null)
        {
            agent.ResetPath();
            agent.velocity = Vector3.zero;
        }
    }

    /// <summary>
    /// Mueve al jugador hacia adelante una distancia definida.
    /// </summary>
    public void MoveForward()
    {
        Vector3 forwardPosition = transform.position + transform.forward * voiceMoveDistance;
        agent.SetDestination(forwardPosition);
    }

    /// <summary>
    /// Mueve al jugador hacia atrás una distancia definida.
    /// </summary>
    public void MoveBackward()
    {
        Vector3 backwardPosition = transform.position - transform.forward * voiceMoveDistance;
        agent.SetDestination(backwardPosition);
    }

    /// <summary>
    /// Detiene cualquier movimiento en curso.
    /// </summary>
    public void StopMovement()
    {
        agent.ResetPath();
        agent.velocity = Vector3.zero;
    }

    /// <summary>
    /// Alias de MoveForward. Puede usarse como “reanudar movimiento”.
    /// </summary>
    public void StartMoving()
    {
        MoveForward();
    }

    /// <summary>
    /// Mueve al jugador a una posición específica en el mundo.
    /// </summary>
    public void MoveTo(Vector3 position)
    {
        if (agent != null && agent.isOnNavMesh)
        {
            agent.SetDestination(position);
        }
    }

    /// <summary>
    /// Añade una llave al inventario si aún no la tiene.
    /// </summary>
    public void CollectKey(string keyName)
    {
        if (!keyNames.Contains(keyName))
        {
            keyNames.Add(keyName);
            Debug.Log("Llave obtenida: " + keyName);
        }
    }

    /// <summary>
    /// Añade salud al jugador, sin pasar el máximo.
    /// </summary>
    public void GainHealth(int amount)
    {
        health = Mathf.Min(maxHealth, health + amount);
        Debug.Log("Salud aumentada. Salud actual: " + health);
    }

    /// <summary>
    /// Añade munición al total disponible.
    /// </summary>
    public void AddAmmo(int amount)
    {
        currentAmmo += amount;
        Debug.Log("Munición añadida. Total actual: " + currentAmmo);
    }
}
