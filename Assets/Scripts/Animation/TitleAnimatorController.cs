using UnityEngine;
using TMPro;

/// <summary>
/// Controlador para animar un título de texto utilizando un gradiente de colores dinámico.
/// Aplica un efecto visual atractivo mediante el cambio de color en los vértices del texto con TMP.
/// </summary>
public class TitleAnimatorController : MonoBehaviour
{
    // Referencia al componente TextMeshProUGUI donde se aplicará el efecto
    public TextMeshProUGUI tmpText;

    // Gradiente de color definido desde el Inspector
    public Gradient colorGradient;

    // Velocidad de cambio del gradiente
    public float speed = 20f;

    // Valor acumulado para la animación (utilizado para calcular el tiempo)
    private float t;

    void Start()
    {
        // Habilita el uso de gradientes de vértice si se ha asignado correctamente el TextMeshPro
        if (tmpText != null)
            tmpText.enableVertexGradient = true;
    }

    void Update()
    {
        // Si el texto no está asignado, salir del método para evitar errores
        if (tmpText == null) return;

        // Acumula el tiempo con base en la velocidad establecida
        t += Time.deltaTime * speed;

        // Calcula un valor oscilante entre 0 y 1 usando una onda seno, para generar un efecto de looping suave
        float lerpT = (Mathf.Sin(t) + 1f) / 2f;

        // Crea un gradiente de color personalizado para los cuatro vértices del texto
        VertexGradient vg = new VertexGradient(
            colorGradient.Evaluate(lerpT),                          // Arriba izquierda
            colorGradient.Evaluate((lerpT + 0.25f) % 1f),          // Arriba derecha
            colorGradient.Evaluate((lerpT + 0.5f) % 1f),           // Abajo izquierda
            colorGradient.Evaluate((lerpT + 0.75f) % 1f)           // Abajo derecha
        );

        // Aplica el gradiente al texto
        tmpText.colorGradient = vg;
    }
}
