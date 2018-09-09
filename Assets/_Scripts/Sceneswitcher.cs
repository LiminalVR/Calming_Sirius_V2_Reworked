//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class Sceneswitcher : MonoBehaviour

//{

//    public Image SpaceFront;

//    public Animation animFadeOut;
//    public Animation animFadeIn;



//    private void Start()
//    {

//        //anim.SetBool("Fade", false);

//        animFadeOut = GetComponent<Animation>();
//        animFadeIn = GetComponent<Animation>();

//    }

//    //private void OnTriggerEnter(Collider other)

//    //{
//    //    if (other.gameObject.name == "Main Camera")
//    //    {

//    //        StartCoroutine(Fading());

//    //        SceneManager.LoadScene("Forest Calming VR");

//    //    }

//    //}


//    //IEnumerator Fading()
//    //{

//    //    anim.SetBool("Fade", true);

//    //    yield return new WaitUntil(() => SpaceFront.color.a == 1);

//    //    yield return new WaitForSeconds(5);

//    //    SceneManager.LoadScene("Forest Calming VR");

//    //}

//    private void OnTriggerEnter(Collider other)
//    {
//        {
//            FadeOut();
//            FadeIn();

//            yield return new WaitForSeconds(5);

//            SceneManager.LoadScene("Forest Calming VR");

//        }
//    }




//    private void FadeOut()
//    {

//        animFadeOut.Play();

//    }

//    private void FadeIn()
//    {

//        animFadeIn.Play();

//    }


//}


