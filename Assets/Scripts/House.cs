using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmRing _alarmRing;
    [SerializeField] private TriggerZone _triggerZone;

    private void OnEnable()
    {
        _triggerZone.RobberEntered += _alarmRing.Ring;
        _triggerZone.RobberExited += _alarmRing.StopRing;
    }

    private void OnDisable()
    {
        _triggerZone.RobberEntered -= _alarmRing.Ring;
        _triggerZone.RobberExited -= _alarmRing.StopRing;
    }
}