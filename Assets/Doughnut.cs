using UnityEngine;

public class Doughnut : MonoBehaviour
{
    [SerializeField] private AudioSource _SwooshAudioSource;

    [ContextMenu("Play")]
    public void PlaySwoosh()
    {
        _SwooshAudioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            PlaySwoosh();
        }
    }
}
