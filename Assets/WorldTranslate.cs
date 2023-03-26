using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTranslate : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(0.0001f, 0, 0);  
    }
}
