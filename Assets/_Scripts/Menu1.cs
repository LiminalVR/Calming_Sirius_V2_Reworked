using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu1 : MonoBehaviour
{
   
    public string myscene;


    public void OnMouseDown()
    {

        SceneManager.LoadScene(myscene);
    }
  }

  






