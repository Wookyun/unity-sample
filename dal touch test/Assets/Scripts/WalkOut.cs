﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class WalkOut : MonoBehaviour {

    public GameObject qt;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision) { 

        if (Input.GetKeyUp(KeyCode.Space) || CrossPlatformInputManager.GetButtonUp("Jump"))
        {
            qt.SetActive(true);

       }
        
    }

    public void LoadTown()
    {
        SceneManager.LoadScene("town");
    }

    public void DeactiveQuerry()
    {
        qt.SetActive(false);
    }


}
