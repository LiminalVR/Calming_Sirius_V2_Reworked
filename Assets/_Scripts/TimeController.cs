  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    [SerializeField] private Light sun; //visable in the inspector serializedfield but no need to adjust
    [SerializeField] private float secondsInFullDay = 120f; //how many seconds in a day

    [Range(0, 1)] [SerializeField] private float currentTimeOfDay = 0; //Range = creates a slider in the inspector
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;



    void Start()
    {
        sunInitialIntensity = sun.intensity;
    }

    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier; //moves the day along - per frame / seconds per day * multiplier

        if (currentTimeOfDay >= 1) //if it ever gets to 1
        {
            currentTimeOfDay = 0; //restarts the day... loops it
        }
    }


    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0); //transforming the local axis of the sun, based on currenttimeofday in 360degrees

        float intensityMultiplier = 1f;

        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) // 0.23f = sunrise, 0.75f = sunset
        {
            intensityMultiplier = 0;
        }

        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f)); //fades the light in on sunrise
        }

        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f))); //fades the light out towrad sunset
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;

    }
}
