using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public  Animator animator;
    private bool isDead = false;
    private float velocity = 0f;

    void Start()
    {
    }

    void Update()
    {
        // Alternar el parámetro booleano "death" con la tecla "D"
        if (Input.GetKeyDown(KeyCode.D))
        {
            isDead = !isDead;
            animator.SetBool("death", isDead);
        }

        // Alternar el parámetro flotante "velocity" entre 0 y 0.5 con "Space"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = (velocity == 0f) ? 0.5f : 0f;
            animator.SetFloat("velocity", velocity);
        }
    }
}
