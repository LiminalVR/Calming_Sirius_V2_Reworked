using Liminal.App.Breath;
using UnityEngine;

public class ScaleBreather : Breather
{
    public Vector3 MinScale = Vector3.one;
    public Vector3 MaxScale = Vector3.one * 5;

    protected override void ModifyValue(float value)
    {
        transform.localScale = Vector3.SlerpUnclamped(MinScale, MaxScale, value);
    }
}
