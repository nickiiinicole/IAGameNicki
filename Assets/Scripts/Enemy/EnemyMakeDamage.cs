using UnityEngine;

/// <summary>
/// Este script controla el da�o que un enemigo le hace al jugador mientras est� dentro de su zona de ataque (trigger).
/// Tambi�n maneja la vida del enemigo y su muerte cuando recibe da�o.
/// </summary>
public class EnemyMakeDamage : MonoBehaviour
{
    [Header("Da�o al Jugador")]
    public float windowTime = 2f; // Tiempo entre cada da�o aplicado si el jugador permanece dentro del trigger
    public int damageAmount = 1;  // Cantidad de da�o infligido por golpe

    private bool playerInside = false;        // Si el jugador est� dentro del trigger
    private float damageTimer = 0f;           // Temporizador para controlar intervalos de da�o
    private GameObject playerRef = null;      // Referencia al objeto jugador

    [Header("Par�metros del Enemigo")]
    [SerializeField] Animator m_Animator;     // Referencia al Animator para animaci�n de ataque
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
    /// Si el jugador est� en el �rea del enemigo, eval�a si debe recibir da�o.
    /// </summary>
    void Update()
    {
        if (playerInside)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= windowTime)
            {
                DamagePlayer();
                damageTimer = 0f; // Reinicia el temporizador para aplicar da�o nuevamente
            }
        }
    }

    /// <summary>
    /// Llama al m�todo para aplicar da�o al jugador y activa la animaci�n de ataque.
    /// </summary>
    private void DamagePlayer()
    {
        Debug.Log($"Jugador da�ado por {damageAmount} punto(s) de da�o");
        m_Animator.SetTrigger("isAttacking");

        if (playerRef != null && playerController != null)
        {
            playerController.SetDamageToApply(damageAmount); // Establece el da�o que luego se aplicar� realmente
        }
    }

    /// <summary>
    /// Este m�todo debe ser llamado desde un Animation Event para aplicar el da�o real.
    /// </summary>
    public void ApplyPlayerDamage()
    {
        playerController.ApplyDamage(); // Aplica el da�o previamente configurado
    }

    /// <summary>
    /// Permite que este enemigo reciba da�o desde otro script.
    /// </summary>
    /// <param name="amount">Cantidad de da�o recibido</param>
    public void ReceiveDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die(); // Ejecuta la muerte si la vida llega a cero
        }
    }

    /// <summary>
    /// Maneja la muerte del enemigo: log y destrucci�n del GameObject.
    /// </summary>
    private void Die()
    {
        Debug.Log("El enemigo ha muerto");
        Destroy(gameObject); // Aqu� podr�as tambi�n reproducir una animaci�n de muerte o efectos
    }

    /// <summary>
    /// Detecta si el jugador entra al �rea de colisi�n del enemigo.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = true;
            playerRef = other.gameObject;
            damageTimer = 0f; // Reinicia el temporizador para evitar da�o inmediato
        }
    }

    /// <summary>
    /// Detecta cuando el jugador sale del trigger y resetea el da�o.
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
