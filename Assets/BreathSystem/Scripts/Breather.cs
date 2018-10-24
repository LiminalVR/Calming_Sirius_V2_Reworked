using UnityEngine;

namespace Liminal.App.Breath
{
    /// <summary>
    /// Extend from Breather to have custom animation to the breathing ratio of a breath solver
    /// </summary>
    public abstract class Breather : MonoBehaviour
    {
        public BreathSolver Solver;

        [Header("Settings")]
        public AnimationCurve CurveIn = AnimationCurve.EaseInOut(0,0,1,1);
        public AnimationCurve CurveOut = AnimationCurve.EaseInOut(0, 0, 1, 1);

        protected virtual void Awake()
        {
            Solver.OnValueChanged += OnSolverValueChanged;
            Solver.OnStateChanged += OnSolverStateChanged;

            _curve = CurveIn;
        }

        protected virtual void OnDestroy()
        {
            Solver.OnValueChanged -= OnSolverValueChanged;
            Solver.OnStateChanged -= OnSolverStateChanged;
        }

        private void OnSolverStateChanged(BreathState state)
        {
            switch (state)
            {
                case BreathState.Inhale:
                    _curve = CurveIn;
                    break;

                case BreathState.Exahle:
                    _curve = CurveOut;
                    break;
            }
        }

        private void OnSolverValueChanged(float value)
        {
            ModifyValue(_curve.Evaluate(value));
        }

        protected abstract void ModifyValue(float value);

        private AnimationCurve _curve;
    }
}
