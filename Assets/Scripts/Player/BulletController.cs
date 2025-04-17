using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // Se destruye sola si no impacta
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyMakeDamage enemy = other.GetComponent<EnemyMakeDamage>();
            if (enemy != null)
            {
                enemy.ReceiveDamage(damage); 
            }

            Destroy(gameObject); // Destruye la bala al impactar
        }
    }
}
