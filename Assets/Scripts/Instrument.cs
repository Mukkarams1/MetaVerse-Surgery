using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.Shared;
using HurricaneVR.Framework.ControllerInput;
using HurricaneVR.Framework.Core;

public class Instrument : MonoBehaviour
{
    [HideInInspector]public GameObject LocationObject;
    [SerializeField] GameObject Prefab;
    [SerializeField] Vector3 contantPoint;
    public Vector3 collisionStayPoint;
    public float controllerPressed ;

    public bool CapsuleNotSpawned = true;

    private void Update()
    {
        controllerPressed = HVRGlobalInputs.Instance.RightTrigger;
        if(GetComponent<HVRGrabbable>().IsBeingHeld == true)
        {
            GameManager.instance.cutter = this;
        }
    }
    private void Start()
    {
        GetComponent<HVRGrabbable>().enabled = false;
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collisionStayPoint = collision.contacts[0].point;
            contantPoint = collision.contacts[0].point;

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            collisionStayPoint = collision.contacts[0].point;
            if (controllerPressed > 0.5f && GameManager.instance.locationObject == null && CapsuleNotSpawned == true)
            {
                CapsuleNotSpawned = false;
                StartCoroutine(SetSpawnedTrue());
                LocationObject = Instantiate(Prefab, collisionStayPoint, Quaternion.identity);
                LocationObject.GetComponent<LocationPrefab>().cutter = this;
                GameManager.instance.AttackTwoPlayerRotate();
            }
        }
            
    }
    public IEnumerator SetSpawnedTrue()
    {
        yield return new WaitForSeconds(3);
        CapsuleNotSpawned = true;
    }
}
