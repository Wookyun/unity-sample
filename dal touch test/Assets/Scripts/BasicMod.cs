using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class BasicMod : MonoBehaviour {

    //RaycastHit hit;

    // Use this for initialization
    void Start () {

    }



    void Update()
    {
        //foreach (Touch t in Input.touches)
        //{
        //    if (Physics.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 1f)), Vector3.forward, out hit, Mathf.Infinity))
        //    {
        //        if (hit.collider.tag == "Home") 
        //        {
        //            SceneManager.LoadScene("Home");
        //        }
        //    }
        //}
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {

            Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Vector2.zero);

            if (raycastHit)
            {
                Debug.Log("Something Hit");
                if (raycastHit.collider.name == "FirstMod")
                {
                    Debug.Log("fm clicked");
                    SceneManager.LoadScene("Home");
                }

                //OR with Tag

                if (raycastHit.collider.CompareTag("SoccerTag"))
                {
                    Debug.Log("Soccer Ball clicked");
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Vector2.zero);

            if (raycastHit)
            {
                
                if (raycastHit.collider.name == "FirstMod")
                {
                    print("fm clicked");
                    SceneManager.LoadScene("Home");
                }

                //OR with Tag

                if (raycastHit.collider.CompareTag("SoccerTag"))
                {
                    Debug.Log("Soccer Ball clicked");
                }
            }

        }

    }
}
