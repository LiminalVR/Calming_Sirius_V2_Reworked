using UnityEngine;

[CreateAssetMenu(menuName = "Liminal/Breath/Ratio")]
public class BreathRatio : ScriptableObject
{
    [SerializeField] private float _InhaleDurationInSeconds = 1.8F;
    [SerializeField] private float _ExhaleDurationInSeconds = 4.2F;
    [SerializeField] private float _PauseDurationInSeconds = 0.3F;

    public float InhaleDurationSeconds { get { return _InhaleDurationInSeconds; } }
    public float ExhaleDurationSeconds { get { return _ExhaleDurationInSeconds; } }
    public float PauseDurationSeconds { get { return _PauseDurationInSeconds; } }
}