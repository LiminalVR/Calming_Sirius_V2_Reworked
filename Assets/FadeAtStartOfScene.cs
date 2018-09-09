using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAtStartOfScene : MonoBehaviour {

    public FadeIn fs;

	// Use this for initialization
	void Start () {
        Debug.Log("calling FromBlack");
        fs.FromBlack();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
