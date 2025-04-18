using UnityEngine;

public class SelfDestroyTimer : MonoBehaviour
{
    public float delayTime;
    public ParticleSystem particle;
    void Start()
    {
        if (particle)
        {
            particle.Play();
        }

        Destroy(gameObject, delayTime); 
    }
}
