using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_FadeScreen : MonoBehaviour

{
    public float speed = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -speed, 0) * 0.05f * Time.deltaTime);
    }
}
