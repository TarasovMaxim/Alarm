using System;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public event Action RobberEntered;
    public event Action RobberExited;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Robber>(out Robber robber))
            RobberEntered?.Invoke();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Robber>(out Robber robber))
            RobberExited?.Invoke();
    }
}