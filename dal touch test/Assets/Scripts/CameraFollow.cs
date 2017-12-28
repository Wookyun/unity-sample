using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject go;
    private Vector3 v3,offset;

	// Use this for initialization
	void Start () {
        v3.z = -10;
        //v3this = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = go.transform.position+ v3;
        //transform.position = new Vector3(go.transform.position.x + offset.x, go.transform.position.y + offset.y, offset.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = go.transform.position - transform.position + v3;
        }
    }
}
