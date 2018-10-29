using UnityEngine;

public class Doughnut : MonoBehaviour
{
    [SerializeField] private Transform _Target;
    [SerializeField] private AudioSource _SwooshAudioSource;
    [SerializeField] private float _ActivationRange = 1.0F;
    private void Awake()
    {
        _transform = transform;
    }

    private void Update ()
    {
        _currentDistance = Vector3.Distance(_transform.position, _Target.position);

        if (_currentDistance <= _ActivationRange)
        {
            _SwooshAudioSource.Play();
            this.enabled = false;
        }
	}

    private Transform _transform = null;
    private float _currentDistance = 0;
}
