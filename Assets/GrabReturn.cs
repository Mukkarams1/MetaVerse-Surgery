using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabReturn : MonoBehaviour
{
    bool isGrabbed = false;
    public GameObject organ;

    Vector3 organPos;
    Quaternion organRot;



    // Start is called before the first frame update
    void Start()
    {
        //organ = GameObject.Find("Circulatory_Heart");
        organPos = organ.transform.position;
        organRot = organ.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = organPos;
        transform.rotation = organRot;
    }

    public void OnGrab()
    {
        Debug.Log("Selected");
    }

    public void OnGrabReturn()
    {
        Debug.Log("DeSelected");
    }
}
