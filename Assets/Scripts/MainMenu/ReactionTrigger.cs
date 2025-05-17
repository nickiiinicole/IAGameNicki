using UnityEngine;
using UnityEngine.Events;

public class ReactionTrigger : MonoBehaviour
{
    [Header("Eventos que se ejecuta al paso del player")]
    public UnityEvent onWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            onWin?.Invoke();
        }
    }
}