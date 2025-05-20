using UnityEngine;

/// <summary>
/// Clase auxiliar para invocar eventos relacionados con el da�o que el enemigo inflige al jugador.
/// Usada principalmente para conectar animaciones con el sistema de da�o mediante Animation Events.
/// </summary>
public class EnemyEventHelper : MonoBehaviour
{
    // Referencia al script que maneja el da�o del enemigo al jugador
    public EnemyMakeDamage enemyMakeDamage;

    /// <summary>
    /// M�todo p�blico que se puede llamar desde eventos de animaci�n
    /// para aplicar da�o al jugador en el momento adecuado de la animaci�n.
    /// </summary>
    public void InvokeDamage()
    {
        enemyMakeDamage.ApplyPlayerDamage();
    }
}
