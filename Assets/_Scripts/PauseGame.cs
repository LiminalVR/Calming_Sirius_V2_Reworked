using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseGame : MonoBehaviour
{

    public bool paused;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
