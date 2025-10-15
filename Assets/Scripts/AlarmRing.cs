using System.Collections;
using UnityEngine;

public class AlarmRing : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioSource;
    private float _changeSpeed = 0.1f;
    private Coroutine _volumeCoroutine;

    private void Awake()
    {
        _alarmAudioSource.volume = 0;
    }

    private IEnumerator ChangeVolume(float value)
    {
        float tolerance = 0.01f;

        while (Mathf.Abs(_alarmAudioSource.volume - value) > tolerance)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, value, Time.deltaTime * _changeSpeed);
            yield return null;
        }

        if (_alarmAudioSource.volume < tolerance)
            _alarmAudioSource.Stop();
    }

    public void Ring()
    {
        float maxValue = 1f;
        _alarmAudioSource.loop = true;
        _alarmAudioSource.Play();

        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ChangeVolume(maxValue));
    }

    public void StopRing()
    {
        float minValue = 0f;

        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ChangeVolume(minValue));
    }
}