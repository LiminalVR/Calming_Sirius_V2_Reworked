using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpScript : MonoBehaviour
{

    public Transform[] target;

    public float speed = 1.0f;

    public float tolerance = 1.0f;

    public Transform currentTarget;

    private int n = 0;

    // Use this for initialization
    void Start()
    {
        currentTarget = target[n];
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, currentTarget.position);

        if (distance < 0.5f)
        {
            ++n;
            n %= target.Length;
        }

        currentTarget = target[n];

        transform.position = Vector3.Slerp(transform.position, currentTarget.position, speed * Time.deltaTime);
    }
}
