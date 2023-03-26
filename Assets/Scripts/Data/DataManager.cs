using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public TextAsset playerdata;
    
    void Start()
    {
        string jsonData = playerdata.text;
        PatientList data = JsonConvert.DeserializeObject<PatientList>(jsonData);
        Debug.Log(data.PatientData[0].Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
