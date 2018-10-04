using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeToBlack : MonoBehaviour

{

	Renderer r;

	// Use this for initialization
	void Start ()
    {

		r = GetComponent<Renderer> ();


	}



    public void CallFadeToBlack()

    {
        {

            StartCoroutine("ToBlack");


        }

    }

    //IEnumerator FromBlack()
    //{
    //    for (float f = 1f; f >= 0; f -= 0.01f)
    //    {
    //        Color c = r.material.color;
    //        c.a = f;
    //        r.material.color = c;
    //        yield return null;
    //    }
    //}


    IEnumerator ToBlack()
    {
        for (float f = 0.001f; f <= 1; f += 0.001f)
        {
            Color c = r.material.color;
            c.a = f;
            r.material.color = c;
            yield return null;
        }
    }



}

