using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour 
    {

// Update is called once per frame
	public void Update () 
	{
		transform.Rotate (new Vector3 (0,0,10) * Time.deltaTime);
	}
}
