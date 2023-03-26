using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework;
using HurricaneVR.Framework.ControllerInput;
using Michsky.UI.ModernUIPack;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public Material orangeMaterial;
    public Instrument cutter;
    [HideInInspector] public GameObject locationObject;
    public GameObject AiLocationPrefab;
    public List<Instrument> instrumentsList;

    public string currentPlayername;
    public GameObject savePanel;

    internal void SetInstrumentforDisease(string diseaseName)
    {
        if(diseaseName == "Incision")
        {
            foreach(var instrument in instrumentsList)
            {
                instrument.GetComponent<HVRGrabbable>().enabled = true;
            }
        }
        if(diseaseName == "Mitral Valve Repair")
        {
            instrumentsList[0].GetComponent<HVRGrabbable>().enabled = true;
            instrumentsList[3].GetComponent<HVRGrabbable>().enabled = true;
        }
       
    }

    public string currentSelectedDisease;
    public GameObject AISwitch;
    public bool AiIsOn;
    [SerializeField] public List<DiseaseLocationPrefabAi> aiPrefabLocation;

    [HideInInspector]public GameObject Patient;
    [Header("Attack Movement Range")]
    [SerializeField] float error;
    [SerializeField] float PlayerMoveError;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(locationObject != null)
        {
           locationObject.transform.position = cutter.collisionStayPoint;
        }
     // Attack();
       AiIsOn = AISwitch.GetComponent<SwitchManager>().isOn;
    }

    internal void CreatePlayer()
    {
        Patient =  Instantiate(playerPrefab, spawnPoint);
        SaveSystem.locationMarkers.Clear();
        SaveSystem.instance.setPath();
        SaveSystem.instance.LoadData();
        if (AiIsOn)
        {
            placeLocationMarkerAI(currentSelectedDisease);
        }
       
    }

    private void placeLocationMarkerAI(string DiseaseName)
    {
        foreach(var report in aiPrefabLocation)
        {
            if(report.reportName == DiseaseName)
            {
                foreach(var disease in report.prefabPos)
                {
                    Instantiate(AiLocationPrefab, disease, Quaternion.identity);
                }
            }
        }
    }

    public void Attack()
    {
        spawnPoint.transform.position += new Vector3(error, 0, 0);
    }
    public void AttackTwoPlayerRotate()
    {
        Patient.transform.Rotate(0, 0, PlayerMoveError);
    }


    [System.Serializable]
    public struct DiseaseLocationPrefabAi
    {
        [SerializeField] public string reportName;
        [SerializeField] public List<Vector3> prefabPos;
    }
}

