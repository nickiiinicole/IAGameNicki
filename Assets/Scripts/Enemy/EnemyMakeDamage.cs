using UnityEngine;

public class EnemyMakeDamage : MonoBehaviour
{
    public float windowTime = 2f; // Tiempo entre cada daño si el jugador sigue en el trigger
    public int damageAmount = 1;  // Cantidad de daño (puede ser ajustable)

    private bool playerInside = false;
    private float damageTimer = 0f;
    private GameObject playerRef = null;

    [SerializeField] Animator m_Animator;
    [SerializeField] private int health = 3;
    PlayerController playerController;

    private void Start()
    {
        playerRef = GameObject.FindWithTag("Player");
        playerController = playerRef.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerInside)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= windowTime)
            {
                DamagePlayer();
                damageTimer = 0f; // Reinicia el temporizador para volver a evaluar
            }
        }
    }

    private void DamagePlayer()
    {
        Debug.Log($"Jugador dañado por {damageAmount} punto(s) de daño");
        m_Animator.SetTrigger("isAttacking");

        if (playerRef != null) {
            
            if (playerController != null) {
                playerController.SetDamageToApply(damageAmount);
            }
        }
    }

    public void ApplyPlayerDamage() {
        playerController.ApplyDamage();
    }

    public void ReceiveDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("El enemigo ha muerto");
        Destroy(gameObject); // O reproducir animación, efectos, etc.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            playerInside = true;
            playerRef = other.gameObject;
            damageTimer = 0f; // Reinicia el contador al entrar
        }
    }

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
