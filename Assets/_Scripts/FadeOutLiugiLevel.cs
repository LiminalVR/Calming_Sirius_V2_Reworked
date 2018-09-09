using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutLiugiLevel : MonoBehaviour

{
    public FadeToBlack f2b;



    // Use this for initialization
    void Start()

    {



    }

    // Update is called once per frame
    void Update()

    {



    }

    private void OnTriggerEnter(Collider other)

    {

        //Debug.Log("Before if");

        if (other.gameObject.name == "EGO_FadeOutTrigger")
        {

            Debug.Log("After if");



            f2b.CallFadeToBlack();


            //        Invoke("ChangeScene", 2.0f);

        }

            //}

            //public void ChangeScene()
            //{
            //    SceneManager.LoadScene("Flower Animation");

        }//
    }
