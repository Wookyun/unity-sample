using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class CameraWalk : MonoBehaviour {

    [SerializeField]
    private float xMax,yMax,xMin,yMin;
    private Transform target;
    private Vector3 camFrame;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
      

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        //scene = GetComponent<Collider2D>().name;
        print("qqqwwwwwww");
        //print(scene);
        if (Input.GetKeyUp(KeyCode.Space) || CrossPlatformInputManager.GetButtonUp("Jump"))
        {
            print("fffffff");
            //querry.SetActive(true);
            //print(querry.name);

        }


    }
    private void LateUpdate()
    {
        //camFrame = target.position - transform.position;
        //if (Mathf.Abs(camFrame.x) > 3 || Mathf.Abs(camFrame.y) > 1)
        //{
           transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
        //}
    }
}
