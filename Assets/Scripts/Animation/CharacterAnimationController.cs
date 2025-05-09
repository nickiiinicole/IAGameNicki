using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    // Referencia al Animator que controla las animaciones del personaje
    public Animator animator;

    // Variable interna para saber si el personaje está "muerto"
    private bool isDead = false;

    // Velocidad actual, se usa para animaciones de movimiento
    private float velocity = 0f;

    void Start()
    {
        // No necesitamos hacer nada por ahora en Start, pero lo dejamos por si se necesita más adelante
    }

    void Update()
    {
        // Si presionamos la tecla D, cambiamos el estado de "muerto" (true o false)
        // Esto actualiza el parámetro booleano "death" del Animator
        if (Input.GetKeyDown(KeyCode.D))
        {
            isDead = !isDead;
            animator.SetBool("death", isDead);
        }

        // Si presionamos Espacio, alternamos el valor de "velocity" entre 0 y 0.5
        // Esto sirve para probar o simular caminar/correr en el Animator
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = (velocity == 0f) ? 0.5f : 0f;
            animator.SetFloat("velocity", velocity);
        }
    }
}
