using System;
using System.Collections;
using UnityEngine;

namespace Liminal.App.Breath
{
    /// <summary>
    /// BreathSolver translates the breathing ratio and output Position
    /// A Breather relies on the BreathSolver for its Position
    /// </summary>
    public class BreathSolver : MonoBehaviour
    {
        public Action<BreathState> OnStateChanged;
        public Action<float> OnValueChanged;

        public BreathRatio Ratio;
        public bool PlayOnAwake;

        private void Awake()
        {
            if (PlayOnAwake)
            {
                Begin();
            }
        }

        [ContextMenu("Begin")]
        public void Begin()
        {
            StartCoroutine(BreatheLoop());
        }

        [ContextMenu("Stop")]
        public void Stop()
        {
            StopAllCoroutines();
        }

        public void ChangeRatio(BreathRatio ratio)
        {
            Ratio = ratio;
            Stop();
            Begin();
        }

        private IEnumerator BreatheLoop()
        {
            while (true)
            {
                yield return BreatheIn();
                yield return Pause();
                yield return BreatheOut();
                yield return Pause();
            }
        }

        private IEnumerator BreatheIn()
        {
            yield return Breathe(Ratio.InhaleDurationInSeconds, BreathState.Inhale);
        }

        private IEnumerator BreatheOut()
        {
            yield return Breathe(Ratio.ExhaleDurationInSeconds, BreathState.Exahle);
        }

        private IEnumerator Pause()
        {
            SetState(BreathState.Pause);
            yield return new WaitForSeconds(Ratio.PauseDurationInSeconds);
        }

        private IEnumerator Breathe(float duration, BreathState state)
        {
            SetState(state);

            for (float i = 0; i <= 1.0F; i += Time.deltaTime / duration)
            {
                SetPositionValue(i,state);
                yield return null;
            }

            SetPositionValue(1, state);
        }

        private void SetPositionValue(float value, BreathState state)
        {
            switch (state)
            {
                case BreathState.Exahle:
                    _currentPositionValue = Mathf.Lerp(1, 0, value);
                    break;

                case BreathState.Inhale:
                    _currentPositionValue = value;
                    break;
            }

            OnValueChanged.InvokeSafe(_currentPositionValue);
        }

        private void SetState(BreathState state)
        {
            _state = state;
            OnStateChanged.InvokeSafe(_state);
        }

        private BreathState _state;
        private float _currentPositionValue;
    }

    public enum BreathState
    {
        Sleep,
        Inhale,
        Exahle,
        Pause
    }
}