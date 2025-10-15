using UnityEngine;

public class AlarmRing : MonoBehaviour
{
    [SerializeField] AudioSource _alarmAudioSource;
    private float _changeSpeed = 0.1f;

    private void Awake()
    {
        _alarmAudioSource.volume = 0;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.TryGetComponent<Robber>(out Robber robber))
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, 1, Time.deltaTime * _changeSpeed);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Robber>(out Robber robber))
        {
            _alarmAudioSource.loop = true;
            _alarmAudioSource.Play();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Robber>(out Robber robber)!)
        {
            _alarmAudioSource.volume = 0;
            _alarmAudioSource.Stop();
        }
    }
}