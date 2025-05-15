using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

/// <summary>
/// Este script controla al jugador usando un NavMeshAgent para navegaci�n
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
        // Evita que el agente gire autom�ticamente (lo maneja el personaje con animaciones)
        agent.updateRotation = false;
    }

    void Update()
    {
        // Si el agente tiene una ruta y a�n no ha llegado al destino
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            // Si lleg� al destino, lo detenemos
            character.Move(Vector3.zero, false, false);
        }
    }

    /// <summary>
    /// Llama a esta funci�n cuando el jugador reciba da�o.
    /// Disminuye la salud y activa la animaci�n correspondiente.
    /// </summary>
    public void TakeDamage(float damageAmount)
    {
        Debug.Log("TakeDamage llamado");
        health -= damageAmount;

        if (health <= 0)
        {
            health = 0;
            animator.SetTrigger("deathTrigger"); // Activa animaci�n de muerte
            mainMenuController.LostGame();
        }
        animator.SetTrigger("isHurting"); // Activa animaci�n de da�o
    }



    /// <summary>
    /// Activa animaci�n de disparo y crea la bala.
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
    /// Dispara una bala si hay munici�n disponible.
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
    /// Mueve al jugador hacia una posici�n indicada.
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
    /// Mueve al jugador hacia atr�s una distancia definida.
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
    /// Alias de MoveForward. Puede usarse como �reanudar movimiento�.
    /// </summary>
    public void StartMoving()
    {
        MoveForward();
    }

    /// <summary>
    /// Mueve al jugador a una posici�n espec�fica en el mundo.
    /// </summary>
    public void MoveTo(Vector3 position)
    {
        if (agent != null && agent.isOnNavMesh)
        {
            agent.SetDestination(position);
        }
    }

    /// <summary>
    /// A�ade una llave al inventario si a�n no la tiene.
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
    /// A�ade salud al jugador, sin pasar el m�ximo.
    /// </summary>
    public void GainHealth(int amount)
    {
        health = Mathf.Min(maxHealth, health + amount);
        Debug.Log("Salud aumentada. Salud actual: " + health);
    }

    /// <summary>
    /// A�ade munici�n al total disponible.
    /// </summary>
    public void AddAmmo(int amount)
    {
        currentAmmo += amount;
        Debug.Log("Munici�n a�adida. Total actual: " + currentAmmo);
    }
}
