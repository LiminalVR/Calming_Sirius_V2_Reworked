using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioPlayer : MonoBehaviour
{

    //set target in inspector
    public AudioClip mySound;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    //set when to initiate code
    void OnMouseDown()
        {

            GetComponent<AudioSource>().
            PlayOneShot(mySound);

        }
    }
