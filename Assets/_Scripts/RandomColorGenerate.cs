using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorGenerate : MonoBehaviour
{

    public void RandomColor() //to access from inspector - custom method stays black
    {
        // Pick a random, saturated and not-too-dark color
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

}