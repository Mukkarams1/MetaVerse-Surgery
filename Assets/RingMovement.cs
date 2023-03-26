using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RingMovementCoroutine());
    }


    IEnumerator RingMovementCoroutine()
    {
        float toAdd = 0.001f;
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (transform.localPosition.z <  2.9 )
            {
                toAdd = 0.0005f;
            }
            if (transform.localPosition.z > 4.6)
            {
                toAdd = -0.0005f;
            }
            transform.Translate(0, 0, toAdd,Space.World);
        }
        

    }
}
