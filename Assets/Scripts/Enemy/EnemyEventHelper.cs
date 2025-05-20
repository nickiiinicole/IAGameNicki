using UnityEngine;

/// <summary>
/// Clase auxiliar para invocar eventos relacionados con el daño que el enemigo inflige al jugador.
/// Usada principalmente para conectar animaciones con el sistema de daño mediante Animation Events.
/// </summary>
public class EnemyEventHelper : MonoBehaviour
{
    // Referencia al script que maneja el daño del enemigo al jugador
    public EnemyMakeDamage enemyMakeDamage;

    /// <summary>
    /// Método público que se puede llamar desde eventos de animación
    /// para aplicar daño al jugador en el momento adecuado de la animación.
    /// </summary>
    public void InvokeDamage()
    {
        enemyMakeDamage.ApplyPlayerDamage();
    }
}
