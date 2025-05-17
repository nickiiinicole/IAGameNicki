using UnityEngine;

public class EnemyEventHelper : MonoBehaviour
{
    public EnemyMakeDamage enemyMakeDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InvokeDamage()
    {
        enemyMakeDamage.ApplyPlayerDamage();
    }
}
