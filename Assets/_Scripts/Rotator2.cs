using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator2 : MonoBehaviour 
    {

// Update is called once per frame
	public void Update () 
	{
		transform.Rotate (new Vector3 (0,0,1) * Time.deltaTime);
	}
}
