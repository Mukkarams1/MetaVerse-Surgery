using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ModeButton : MonoBehaviour
{
    // Start is called before the first frame update

    public delegate void ToogleModeEvent();
    public event ToogleModeEvent ToggleMode;

    void Start()
    {
        //ToggleMode += test;
    }

    private void test()
    {
        Debug.Log("Event Working");
    }

    private void OnCollisionEnter(Collision collision)
    {
        ToggleMode.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        ToggleMode.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
