using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour

{
    public FadeToBlack f2b;



	// Use this for initialization
	void Start ()

    {



    }
	
	// Update is called once per frame
	void Update ()

    {
		


	}

    private void OnTriggerEnter(Collider other)

    {

        //Debug.Log("Before if");

        if (other.gameObject.name == "EGO_FadeOutTrigger")
        {

            //Debug.Log("After if");



            //f2b.CallFadeToBlack();

            //Debug.Log("Calling FADE TO Black");


            Invoke("ChangeScene", 10.0f);

            //SceneManager.LoadScene("EndScene_Black");

        }

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("EndScene_Black");

    }
}
