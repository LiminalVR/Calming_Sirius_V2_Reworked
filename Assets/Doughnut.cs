using UnityEngine;

public class Doughnut : MonoBehaviour
{
    [SerializeField] private AudioSource _SwooshAudioSource;

    [ContextMenu("Play")]
    public void PlaySwoosh()
    {
        Debug.Log("Play");
        _SwooshAudioSource.Play();
    }
}
