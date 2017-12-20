using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkIn : MonoBehaviour {

    public GameObject getin;
    static string scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D collision)
    {
        scene = GetComponent<Collider2D>().name;
        //print(scene);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            getin.SetActive(true);

        }
        

    }

    public void LoadTown()
    {
        print(scene);
        SceneManager.LoadScene(scene);
    }

    public void DeactiveQuerry()
    {
        getin.SetActive(false);
    }
}
