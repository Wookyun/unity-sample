using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitfor : MonoBehaviour
{
    public GameObject sb;

	void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(1);
      sb.gameObject.SetActive(true);
    }
}

