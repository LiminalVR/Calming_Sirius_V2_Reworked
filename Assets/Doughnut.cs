using System.Collections;
using UnityEngine;

public class Doughnut : MonoBehaviour
{
    [SerializeField] private AudioSource _SwooshAudioSource;
    [SerializeField] private float _Speed = 1;
    [SerializeField] private float _MaxDistance = 70;

    [SerializeField] private AnimationCurve curveIn = AnimationCurve.Linear(0,0,1,1);
    [SerializeField] private AnimationCurve curveOut = AnimationCurve.Linear(0, 0, 1, 1);

    private void Awake()
    {
        _startPos = transform.position;
        _startScale = transform.localScale;

        Play();
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _Speed;

        var dist = Vector3.Distance(_startPos, transform.position);

        if (dist >= _MaxDistance && !_isAnimating)
        {
            StartCoroutine(Stop());
        }
    }

    public void Play()
    {
        transform.position = _startPos;
        transform.localScale = Vector3.zero;
        StartCoroutine(Scale(_startScale, curveIn, 10));
    }

    private IEnumerator Stop()
    {
        yield return Scale(Vector3.zero, curveOut, 5);
        Play();
    }

    private IEnumerator Scale(Vector3 scale, AnimationCurve curve, float duration)
    {
        _isAnimating = true;

        var currentScale = transform.localScale;

        for (float i = 0; i < 1.0F; i += Time.deltaTime / duration)
        {
            transform.localScale = Vector3.Lerp(currentScale, scale, curve.Evaluate(i));
            yield return null;
        }

        _isAnimating = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            PlaySwoosh();
        }
    }

    [ContextMenu("Play")]
    public void PlaySwoosh()
    {
        _SwooshAudioSource.Play();
    }

    private Vector3 _startPos = Vector3.zero;
    private Vector3 _startScale = Vector3.zero;
    private bool _isAnimating = false;
}
