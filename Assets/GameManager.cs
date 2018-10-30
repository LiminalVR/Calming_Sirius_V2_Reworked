using Liminal.App.Breath;
using Liminal.Core.Fader;
using Liminal.SDK.Core;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public AudioMixerGroup MainMixerGroup;
    public ParticleSystem SpiralPS;
    public AnimationCurve SpiralCurve;
    public float TotalGameDuration = 336;

    public BreathSolver BreathSolver;
    public BreathRatio[] BreathRatios;

    private IEnumerator Start()
    {
        BreathSolver.OnBreathCycleEnd += OnBreathCycleEnd;
        yield return GameLoop();
        yield return Outro();
    }

    private void OnBreathCycleEnd()
    {
        _breathCount++;

        switch (_breathCount)
        {
            case 10:
                _breathRatioIndex = 1;
                break;

            case 15:
                _breathRatioIndex = 2;
                break;

            case 25:
                _breathRatioIndex = 3;
                break;
        }

        BreathSolver.ChangeRatio(BreathRatios[_breathRatioIndex]);
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
        ScreenFader.Instance.FadeToBlack(13);
        this.SetAudioMixerVolume(MainMixerGroup.audioMixer, "Volume", 0, 4);
        yield return ScreenFader.Instance.WaitUntilFadeComplete();
        yield return new WaitForSeconds(2);
        ExperienceApp.End();
    }

    private int _breathCount = 0;
    private int _breathRatioIndex = 0;
}
