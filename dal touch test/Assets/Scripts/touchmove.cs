using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class touchmove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(CrossPlatformInputManager.GetAxis("Horizontal"));
        //print(Input.GetAxis("Horizontal"));
    }

    void GoUp()
    {
        CrossPlatformInputManager.VirtualAxis vaxis;
    }
}
