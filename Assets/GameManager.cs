using Liminal.Core.Fader;
using Liminal.SDK.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public AudioMixerGroup MainMixerGroup;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(180);
        ScreenFader.Instance.FadeToBlack(5);
        this.SetAudioMixerVolume(MainMixerGroup.audioMixer, "Volume", 0, 4);
        yield return ScreenFader.Instance.WaitUntilFadeComplete();
        yield return new WaitForSeconds(2);
        ExperienceApp.End();
    }
}
