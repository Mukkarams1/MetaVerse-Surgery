using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PatientDetailsPrefabUi : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    [SerializeField] TextMeshProUGUI patientNameText;
    [SerializeField] TextMeshProUGUI patientDiseaseText;
   // [SerializeField] TextMeshProUGUI patientDetailsText;
    [SerializeField] GameObject DiseasesPrefab;
    public Transform Content;

    [SerializeField] Image PatientImg;
    public Button btn;
    public string Patientname;
    [HideInInspector]public PatientDataUI patientDataUI;
    public GameObject DiseasePanel;

    public List<TextMeshProUGUI> text;
    Color defColr;
    public void SetUi(string name, string disease , string Details , List<DiseasesData> data)
    {
        btn.onClick.AddListener(delegate { OnBtnClicked(data); });
        Patientname = name;
        patientNameText.text = name;
        patientDiseaseText.text = disease;
        defColr = patientNameText.color;
   //     patientDetailsText.text = Details;
    }
  
    void OnBtnClicked(List<DiseasesData> data)
    {
        DiseasePanel.SetActive(true);
        patientDataUI.gameObject.SetActive(false);
        GameManager.instance.currentPlayername = Patientname;
        SetDiseaseDataUi(data);
        
    }
    public void SetDiseaseDataUi(List<DiseasesData> data)
    {
        foreach (var diseasesData in data)
        {
            var prefab = Instantiate(DiseasesPrefab, Content);
            prefab.GetComponent<DeseasePrefabUI>().SetUI(diseasesData.name);
            prefab.GetComponent<DeseasePrefabUI>().diseasePanel = DiseasePanel;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach(var textasset in text)
        {
            textasset.color = defColr;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var textasset in text)
        {
            textasset.color = Color.white;
        }
    }
}
