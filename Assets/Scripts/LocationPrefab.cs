using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework;
using HurricaneVR.Framework.ControllerInput;

public class LocationPrefab : MonoBehaviour
{
    public Material greenMaterial;
    public Material BlackMaterial;
    public Material OrangeMaterial;
    public float GrabPressed;
    public Instrument cutter;
    private void Awake()
    {
        SaveSystem.locationMarkers.Add(this);
    }
    internal void OnEnterRadius()
    {
        gameObject.GetComponent<MeshRenderer>().material = greenMaterial;
        
    }

    private void Update()
    {
        GrabPressed = HVRGlobalInputs.Instance.RightTrigger;
        if(GrabPressed < 0.3f)
        {
            GameManager.instance.locationObject = null;
        }
    }

    internal void OnStayRadius(GameObject collider)
    {
        if (GrabPressed > 0.3f)
        {
            GameManager.instance.locationObject = collider.gameObject;
            GetComponent<MeshRenderer>().material = OrangeMaterial;
        }
    }

    internal void OnRadiusExit()
    {
        gameObject.GetComponent<MeshRenderer>().material = BlackMaterial;
        GameManager.instance.locationObject = null;
    }
}
