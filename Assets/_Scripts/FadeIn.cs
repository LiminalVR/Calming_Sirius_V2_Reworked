using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeIn : MonoBehaviour

{

    Renderer r;

    // Use this for initialization
    void Start()
    {

        r = GetComponent<Renderer>();


    }



    public void FromBlack()

    {
        {
            //Debug.Log("FromBlack has been called on FadeIn");

            if (!r)
            {
               // Debug.Log("no renderer, fixing");
                r = GetComponent<Renderer>();
            }
            

            StartCoroutine("fadeIn");


        }

    }

    IEnumerator fadeIn()
    {
        for (float f = 3.0f; f >= 0; f -= 0.01f)
        {
            
            Color c = r.material.color;
            c.a = f;
            r.material.color = c;

            yield return null;
        }
    }


    //IEnumerator ToBlack()
    //{
    //    for (float f = 0.01f; f <= 1; f += 0.01f)
    //    {
    //        Color c = r.material.color;
    //        c.a = f;
    //        r.material.color = c;
    //        yield return null;
    //    }
    //}



}
