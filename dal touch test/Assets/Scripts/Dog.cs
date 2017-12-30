using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    private AudioSource bark;
    private float distance;
    public GameObject playerboy;
    

    // Use this for initialization
    void Start () {
        bark = GetComponent<AudioSource>();
        OnVariableChange += VariableChangeHandler;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(playerboy.transform.position, transform.position);
        print(DistanceBool);

        if (distance <= 7)
            DistanceBool = true;
        else
            DistanceBool = false;
   
    }


    private bool distanceBool = false;
    public bool DistanceBool
    {
        get { return distanceBool; }
        set
        {
            if (value == distanceBool)
                return;

            distanceBool = value;


            if (OnVariableChange != null)
            {
               
                  
                


                OnVariableChange(distanceBool);

            }

        }
    }

    public delegate void OnVariableChangeDelegate(bool newV);
    public event OnVariableChangeDelegate OnVariableChange;

    private void VariableChangeHandler(bool newVal)
    {
        if (newVal == true)
        {
            bark.Play();
            print("play?");
        }
          
        else
        {
            bark.Pause();
            print("pause?");
        }
            
    }

}
