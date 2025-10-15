using System.Collections;
using UnityEngine;

public class AlarmRing : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioSource;
    [SerializeField] private TriggerZone _triggerZone;
    private float _changeSpeed = 0.1f;

    private void Awake()
    {
        _alarmAudioSource.volume = 0;
    }

    private void OnEnable()
    {
        _triggerZone.OnRobberEntered += Ring;
        _triggerZone.OnRobberExited += StopRing;
    }

    private void OnDisable()
    {
        _triggerZone.OnRobberEntered -= Ring;
        _triggerZone.OnRobberExited -= StopRing;
    }

    private IEnumerator IncreaseVolume()
    {
        int maxValue = 1;

        while (_alarmAudioSource.volume < maxValue)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, maxValue, Time.deltaTime * _changeSpeed);
            yield return null;
        }
    }

    private void Ring()
    {
        _alarmAudioSource.loop = true;
        _alarmAudioSource.Play();
        StartCoroutine(IncreaseVolume());
    }

    private void StopRing()
    {
        _alarmAudioSource.volume = 0;
        _alarmAudioSource.Stop();
    }
}