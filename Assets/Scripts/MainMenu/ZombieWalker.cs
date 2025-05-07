using UnityEngine;

public class ZombieWalker : MonoBehaviour
{
    public float speed = 2f;
    public float destroyX = 30f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > destroyX)
        {
            Destroy(gameObject);
        }
    }
}
