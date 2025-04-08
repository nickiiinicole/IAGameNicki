using UnityEngine;

public class EnemyMakeDamage : MonoBehaviour
{
    public float windowTime = 2f; // Tiempo entre cada daño si el jugador sigue en el trigger
    public int damageAmount = 1;  // Cantidad de daño (puede ser ajustable)

    private bool playerInside = false;
    private float damageTimer = 0f;
    private GameObject playerRef = null;

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

        if (playerRef != null) {
            PlayerController playerController = playerRef.GetComponent<PlayerController>();
            if (playerController != null) {
                playerController.TakeDamage(damageAmount);
            }
        }
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
