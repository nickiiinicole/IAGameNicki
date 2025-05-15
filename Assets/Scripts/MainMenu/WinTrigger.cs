using UnityEngine;
using UnityEngine.Events;

public class WinTrigger : MonoBehaviour
{
    [Header("Evento que se ejecuta al ganar")]
    public UnityEvent onWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            onWin?.Invoke();
        }
    }
}