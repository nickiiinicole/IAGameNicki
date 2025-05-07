using UnityEngine;
using TMPro;

public class TitleAnimatorController : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public Gradient colorGradient;
    public float speed = 20f;

    private float t;

    void Start()
    {
        if (tmpText != null)
            tmpText.enableVertexGradient = true;
    }

    void Update()
    {
        if (tmpText == null) return;

        t += Time.deltaTime * speed;
        float lerpT = (Mathf.Sin(t) + 1f) / 2f;

        VertexGradient vg = new VertexGradient(
            colorGradient.Evaluate(lerpT),
            colorGradient.Evaluate((lerpT + 0.25f) % 1f),
            colorGradient.Evaluate((lerpT + 0.5f) % 1f),
            colorGradient.Evaluate((lerpT + 0.75f) % 1f)
        );

        tmpText.colorGradient = vg;
    }
}
