using UnityEngine;

/// <summary>
/// Este script controla el daño que un enemigo le hace al jugador mientras esté dentro de su zona de ataque (trigger).
/// También maneja la vida del enemigo y su muerte cuando recibe daño.
/// </summary>
public class EnemyMakeDamage : MonoBehaviour
{
    [Header("Daño al Jugador")]
    public float windowTime = 2f; // Tiempo entre cada daño aplicado si el jugador permanece dentro del trigger
    public int damageAmount = 1;  // Cantidad de daño infligido por golpe

    private bool playerInside = false;        // Si el jugador está dentro del trigger
    private float damageTimer = 0f;           // Temporizador para controlar intervalos de daño
    private GameObject playerRef = null;      // Referencia al objeto jugador

    [Header("Parámetros del Enemigo")]
    [SerializeField] Animator m_Animator;     // Referencia al Animator para animación de ataque
    [SerializeField] private int health = 3;  // Vida del enemigo

    private PlayerController playerController;  // Referencia al controlador del jugador

    /// <summary>
    /// Inicializa referencias necesarias al comenzar.
    /// </summary>
    private void Start()
    {
        playerRef = GameObject.FindWithTag("Player");
        playerController = playerRef.GetComponent<PlayerController>();
    }

    /// <summary>
    /// Si el jugador está en el área del enemigo, evalúa si debe recibir daño.
    /// </summary>
    void Update()
    {
        if (playerInside)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= windowTime)
            {
                DamagePlayer();
                damageTimer = 0f; // Reinicia el temporizador para aplicar daño nuevamente
            }
        }
    }

    /// <summary>
    /// Llama al método para aplicar daño al jugador y activa la animación de ataque.
    /// </summary>
    private void DamagePlayer()
    {
        Debug.Log($"Jugador dañado por {damageAmount} punto(s) de daño");
        m_Animator.SetTrigger("isAttacking");

        if (playerRef != null && playerController != null)
        {
            playerController.SetDamageToApply(damageAmount); // Establece el daño que luego se aplicará realmente
        }
    }

    /// <summary>
    /// Este método debe ser llamado desde un Animation Event para aplicar el daño real.
    /// </summary>
    public void ApplyPlayerDamage()
    {
        playerController.ApplyDamage(); // Aplica el daño previamente configurado
    }

    /// <summary>
    /// Permite que este enemigo reciba daño desde otro script.
    /// </summary>
    /// <param name="amount">Cantidad de daño recibido</param>
    public void ReceiveDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die(); // Ejecuta la muerte si la vida llega a cero
        }
    }

    /// <summary>
    /// Maneja la muerte del enemigo: log y destrucción del GameObject.
    /// </summary>
    private void Die()
    {
        Debug.Log("El enemigo ha muerto");
        Destroy(gameObject); // Aquí podrías también reproducir una animación de muerte o efectos
    }

    /// <summary>
    /// Detecta si el jugador entra al área de colisión del enemigo.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = true;
            playerRef = other.gameObject;
            damageTimer = 0f; // Reinicia el temporizador para evitar daño inmediato
        }
    }

    /// <summary>
    /// Detecta cuando el jugador sale del trigger y resetea el daño.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = false;
            playerRef = null;
            damageTimer = 0f;
        }
    }
}
