using UnityEngine;

public class Doughnut : MonoBehaviour
{
    [SerializeField] private AudioSource _SwooshAudioSource;

    public void PlaySwoosh()
    {
        _SwooshAudioSource.Play();
    }
}
