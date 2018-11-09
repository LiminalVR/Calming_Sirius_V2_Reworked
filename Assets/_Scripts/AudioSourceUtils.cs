using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public static class AudioSourceUtils
{
    public static void SetSourceVolume(MonoBehaviour mono, AudioSource source, float volume, float duration)
    {
        mono.StartCoroutine(LerpVolume(source, volume, duration));
    }

    private static IEnumerator LerpVolume(AudioSource source, float volume, float duration)
    {
        var currentVolume = source.volume;

        for (float i = 0; i < 1.0F; i += Time.deltaTime / duration)
        {
            source.volume = Mathf.Lerp(currentVolume, volume, i);
            yield return null;
        }

        source.volume = volume;
    }
}

public static class AudioMixerUtils
{
    public static void SetAudioMixerVolume(this MonoBehaviour mono, AudioMixer mixer, string id, float volume, float duration)
    {
        var db = Mathf.Lerp(-50, 0, volume);
        mono.StartCoroutine(LerpMixer(mixer, id, db, duration));
    }

    public static void SetAudioMixerDB(this MonoBehaviour mono, AudioMixer mixer, string id, float db, float duration)
    {
        mono.StartCoroutine(LerpMixer(mixer, id, db, duration));
    }

    private static IEnumerator LerpMixer(AudioMixer mixer, string id, float db, float duration)
    {
        var currentDB = 0.0F;
        mixer.GetFloat(id, out currentDB);

        for (float i = 0; i < 1.0F; i += Time.deltaTime / duration)
        {
            var value = Mathf.Lerp(currentDB, db, i);
            mixer.SetFloat(id, value);
            yield return null;
        }

        mixer.SetFloat(id, db);
    }
}