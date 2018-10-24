using UnityEngine;

[CreateAssetMenu(menuName = "Liminal/Breath/Ratio")]
public class BreathRatio : ScriptableObject
{
    public float InhaleDurationInSeconds = 1.8F;
    public float ExhaleDurationInSeconds = 4.2F;
    public float PauseDurationInSeconds = 0.3F;
}