using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class PatientDataUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject contentArea;
    [SerializeField] public List<PatientDetails> patientData;
    public GameObject DetailsPrefab;
    public GameObject diseasePanel;
    public Transform DiseaseDataContent;


    void Start()
    {
        PopulateEnvironmentTabs();
       
    }

    private void PopulateEnvironmentTabs()
    {
        foreach (var PatientDetails in patientData)
        {
            PatientDetailsPrefabUi PatientUi =  GameObject.Instantiate(DetailsPrefab, contentArea.transform).GetComponent<PatientDetailsPrefabUi>();
            PatientUi.SetUi(PatientDetails.name, PatientDetails.disease, PatientDetails.description , PatientDetails.Report);
            PatientUi.patientDataUI = gameObject.GetComponent<PatientDataUI>();
            PatientUi.DiseasePanel = diseasePanel;
            PatientUi.Content = DiseaseDataContent;
        }
    }
    
    [System.Serializable]
    public struct PatientDetails
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public string disease;
        [SerializeField]
        public string description;

        [SerializeField] public List<DiseasesData> Report;

    }
    
}
