using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInTrigger : MonoBehaviour

{
    public FadeIn fadeIn;



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

        Debug.Log("Before if");

        if (other.gameObject.name == "OVRCameraRig")
        {

            Debug.Log("After if");



            fadeIn.FromBlack();


            //Invoke("ChangeScene", 2.0f);

        }

    }

    //public void ChangeScene()
    //{
    //    SceneManager.LoadScene("Flower Animation");

    //}
}
