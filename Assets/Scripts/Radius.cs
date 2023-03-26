using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    LocationPrefab locationPrefab;
    private void Awake()
    {
        locationPrefab = GetComponentInParent<LocationPrefab>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cutter")
        {
            locationPrefab.OnEnterRadius();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cutter")
        {
            locationPrefab.OnStayRadius(this.gameObject.transform.parent.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cutter")
        {
            locationPrefab.OnRadiusExit();
        }
    }
}
