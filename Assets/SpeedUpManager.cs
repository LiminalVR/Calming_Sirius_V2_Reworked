#if UNITY_EDITOR
using UnityEngine;

/// <summary>
/// Use for speeding up the experience and audio simultanaeosly 
/// </summary>
public class SpeedUpManager : MonoBehaviour
{
    public AudioSource MainAudioSource;

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            MainAudioSource.pitch = 20;
            Time.timeScale = 20;
        }
        else
        {
            MainAudioSource.pitch = 1;
            Time.timeScale = 1;
        }
    }
}
#endif