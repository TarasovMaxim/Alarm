using System;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public event Action OnRobberEntered;
    public event Action OnRobberExited;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Robber>(out Robber robber))
            OnRobberEntered?.Invoke();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Robber>(out Robber robber))
            OnRobberExited?.Invoke();
    }
}