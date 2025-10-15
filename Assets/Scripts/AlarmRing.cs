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
        _triggerZone.RobberEntered += Ring;
        _triggerZone.RobberExited += StopRing;
    }

    private void OnDisable()
    {
        _triggerZone.RobberEntered -= Ring;
        _triggerZone.RobberExited -= StopRing;
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

    private IEnumerator DecreaseVolume()
    {
        int minValue = 0;

        while (_alarmAudioSource.volume > minValue)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, minValue, Time.deltaTime * _changeSpeed);
            yield return null;
        }

        _alarmAudioSource.Stop();
    }

    private void Ring()
    {
        _alarmAudioSource.loop = true;
        _alarmAudioSource.Play();
        StartCoroutine(IncreaseVolume());
        StopCoroutine(DecreaseVolume());
    }

    private void StopRing()
    {
        StartCoroutine(DecreaseVolume());
        StopCoroutine(IncreaseVolume());
    }
}