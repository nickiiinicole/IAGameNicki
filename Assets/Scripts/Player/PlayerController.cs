using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using TMPro;
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
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Salud")]
    [SerializeField] private float health;
    [SerializeField] private int ammo;
    [SerializeField] private float voiceMoveDistance = 5f;
    [SerializeField] Animator animator;

    public List<string> keyNames = new List<string>();
    [SerializeField] private float maxHealth = 100f;

    public MainMenuController mainMenuController;
    public bool playerInControl = false;
    public float playerRotationStep = 20.0f;
    public TextMeshProUGUI textMeshProAmmo;
    public TextMeshProUGUI textMeshProHealth;

    [Header("Configuracion movimiento por voz")]
    public GameObject destinationGizmo;
    private float maxDistance = 15f;
    private float moveDistance = 5f;
    private float stopDistance = 0.1f;
    private float stepRotation = 20f;

    public bool DebugKeyboard = false;

    private Vector3 currentTarget;

    void Start()
    {
        // Evita que el agente gire autom�ticamente (lo maneja el personaje con animaciones)
        agent.updateRotation = true;
    }

    public void SetPlayerInControl(bool controlStartus) {
        playerInControl= controlStartus;
    }

    void Update()
    {
        textMeshProAmmo.text = ammo.ToString();
        textMeshProHealth.text = health.ToString();

        animator.SetFloat("velocity", agent.velocity.sqrMagnitude);

        print(agent.velocity.sqrMagnitude);

        if (DebugKeyboard && playerInControl) {
            HandleInput();
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveForward();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBackward();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopMovement();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TurnLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TurnRight();
        }
    }

    /// <summary>
    /// Mueve al jugador hacia adelante.
    /// </summary>
    public void MoveForward()
    {
        MoveInDirection(transform.forward);
    }

    /// <summary>
    /// Mueve al jugador hacia atr�s.
    /// </summary>
    public void MoveBackward()
    {
        MoveInDirection(-transform.forward);
    }

    /// <summary>
    /// Detiene el movimiento actual del jugador.
    /// </summary>
    public void StopMovement()
    {
        Vector3 stopPoint = transform.position + transform.forward * stopDistance;
        SetDestination(stopPoint);
    }

    /// <summary>
    /// Gira el jugador hacia la izquierda.
    /// </summary>
    public void TurnLeft()
    {
        HandleRotation(-stepRotation);
    }

    /// <summary>
    /// Gira el jugador hacia la derecha.
    /// </summary>
    public void TurnRight()
    {
        HandleRotation(stepRotation);
    }

    /// <summary>
    /// Maneja la l�gica de giro seg�n si el agente est� en movimiento o no.
    /// </summary>
    private void HandleRotation(float angle)
    {
        if (agent.remainingDistance > 0.1f && !agent.pathPending)
        {
            // Si se est� moviendo, redirige con nueva direcci�n rotada
            Vector3 dir = Quaternion.Euler(0, angle, 0) * (currentTarget - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, currentTarget);
            MoveInDirection(dir, distance);
        }
        else
        {
            // Si est� quieto, crea un destino muy cercano con la nueva orientaci�n
            RotateInPlaceViaDestination(angle);
        }
    }

    /// <summary>
    /// Gira en el sitio movi�ndose a un destino muy cercano rotado.
    /// </summary>
    private void RotateInPlaceViaDestination(float angle)
    {
        Vector3 rotatedDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
        Vector3 rotatedTarget = transform.position + rotatedDirection.normalized * 1.1f; // puedes ajustar la distancia

        SetDestination(rotatedTarget);
    }

    void MoveInDirection(Vector3 direction, float? customDistance = null)
    {
        float distanceToTarget = customDistance ?? moveDistance;

        Vector3 target = transform.position + direction.normalized * distanceToTarget;
        float actualDistance = Vector3.Distance(transform.position, target);

        // Limitar el movimiento a m�ximo 15m del personaje
        if (Vector3.Distance(transform.position, target) > maxDistance)
        {
            target = transform.position + direction.normalized * maxDistance;
        }

        SetDestination(target);
    }

    void SetDestination(Vector3 target)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(target, out hit, 1.0f, NavMesh.AllAreas))
        {
            currentTarget = hit.position;
            agent.SetDestination(currentTarget);
            if (destinationGizmo != null)
            {
                destinationGizmo.transform.position = currentTarget;
            }
        }
    }

    /// <summary>
    /// Llama a esta funci�n cuando el jugador reciba da�o.
    /// Disminuye la salud y activa la animaci�n correspondiente.
    /// </summary>
    /// 

    public float damgeToApply = 0;
    public void SetDamageToApply(float damageAmount)
    {
        Debug.Log("SetDamageToApply llamado");
        damgeToApply = damageAmount;
    }

    public void ApplyDamage()
    {
        if (health <= 0) {
            return;
        }

        health -= damgeToApply;

        if (health <= 0)
        {
            health = 0;
            animator.SetTrigger("death"); // Activa animaci�n de muerte
            playerInControl = false;
            mainMenuController.LostGame();
        }
        else {
            animator.SetTrigger("isHurting"); // Activa animaci�n de da�o
        }
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
        ammo += amount;
        Debug.Log("Munici�n a�adida. Total actual: " + ammo);
    }
}
