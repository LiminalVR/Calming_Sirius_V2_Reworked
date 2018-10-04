
using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
 
public class AudioFadeOut : MonoBehaviour

{

    public int secondsToFadeOut = 10;

    public AudioSource music;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "EGO_FadeOutTrigger")
        {

            // Call findAudioAndFadeOut Coroutine
            StartCoroutine(findAudioAndFadeOut());
        }

    }

    IEnumerator findAudioAndFadeOut()
    {
        // Find Audio Music in scene

        AudioSource music = GameObject.Find("OVRCameraRig").GetComponent<AudioSource>();

        // Check Music Volume and Fade Out
        while (music.volume > 0.01f)
        {
            music.volume -= Time.deltaTime / secondsToFadeOut;
            yield return null;
        }

        // Make sure volume is set to 0
        music.volume = 0;

        // Stop Music
        music.Stop();

        // Destroy
        Destroy(this);
    }
}