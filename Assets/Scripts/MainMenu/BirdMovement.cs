using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    //TODO: crear un objeto 2D de un sprite de pajaro y asiganmos este script 
    public float speed = 2f;
    public float amplitude = 20f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector3(Time.time * speed, y, 0f);
    }
}
