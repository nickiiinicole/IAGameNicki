using UnityEngine;
using UnityEngine.UIElements;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public float lifeTime = 2f;
    public GameObject particlePrefab;

    void Start()
    {
        Destroy(gameObject, lifeTime); // Se destruye sola si no impacta
    }

    void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collisionObject)
    {
        if (collisionObject.gameObject.tag == "Enemy")
        {
            EnemyController enemyController = collisionObject.gameObject.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(damage);
            }

            if (particlePrefab != null)
            {
                GameObject spawnedEffect = Instantiate(particlePrefab, gameObject.transform.position, gameObject.transform.rotation);
            }

            Destroy(gameObject); // Destruye la bala al impactar
        }
    }
}
