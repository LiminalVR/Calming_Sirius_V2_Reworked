using Liminal.Core.Fader;
using Liminal.SDK.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public AudioMixerGroup MainMixerGroup;
    public ParticleSystem SpiralPS;
    public AnimationCurve SpiralCurve;
    public float TotalGameDuration = 180;

    private IEnumerator Start()
    {
        yield return GameLoop();
        yield return Outro();
    }

    private IEnumerator GameLoop()
    {
        var SpritalMain = SpiralPS.main;

        for (float i = 0; i < 1.0F; i += Time.deltaTime / TotalGameDuration)
        {
            SpritalMain.simulationSpeed = Mathf.Lerp(0.25F, 0.05F, SpiralCurve.Evaluate(i));
            yield return null;
        }
    }

    private IEnumerator Outro()
    {
        ScreenFader.Instance.FadeToBlack(5);
        this.SetAudioMixerVolume(MainMixerGroup.audioMixer, "Volume", 0, 4);
        yield return ScreenFader.Instance.WaitUntilFadeComplete();
        yield return new WaitForSeconds(2);
        ExperienceApp.End();
    }
}
