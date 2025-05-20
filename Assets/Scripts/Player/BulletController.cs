using UnityEngine;
using UnityEngine.UIElements;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public float lifeTime = 2f;
    public GameObject particlePrefab;
    private Rigidbody rb;

    void Start()
    {
        //preuba
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        //finpreubea
       
        Destroy(gameObject, lifeTime); // Se destruye sola si no impacta
    }

    void FixedUpdate()
    {
        //preuba
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        //finpreubea
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bala entró en trigger con: " + other.gameObject.name);

        Transform t = other.transform;
        while (t != null)
        {
            if (t.gameObject.tag == "Enemy")
            {
                Debug.Log("Trigger con enemigo: " + t.name);

                EnemyController enemyController = t.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.TakeDamage(damage);
                    Debug.Log("Enemigo recibió daño");
                }

                if (particlePrefab != null)
                {
                    Instantiate(particlePrefab, transform.position, transform.rotation);
                }

                Destroy(gameObject);
                break;
            }
            t = t.parent;
        }
    }

}
