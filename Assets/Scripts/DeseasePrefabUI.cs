using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeseasePrefabUI : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public Text diseaseNameText;
    public Image diseaseImg;
   [HideInInspector] public string diseasename;
    public GameObject diseasePanel;
    public Sprite incision;
    public Sprite MRI;
    public Sprite ECG;
    public Sprite MitralValveRepair;
    public Sprite Fracture;

    public Image innerImage;
    Color defaultColor;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Onclick);
        defaultColor = diseaseImg.color;
    }

    private void Onclick()
    {
        GameManager.instance.currentSelectedDisease = diseasename;
        diseasePanel.SetActive(false);
        GameManager.instance.savePanel.SetActive(true);
        GameManager.instance.CreatePlayer();
        GameManager.instance.SetInstrumentforDisease(diseasename);
        
    }

    internal void SetUI(string Name)
    {
        diseaseNameText.text = Name.ToString();
        Debug.Log("disease name" + Name);
        diseasename = Name.ToString();
        if (Name.StartsWith("Incision"))
        {
            diseaseImg.sprite = incision;
        }
        else if (Name.StartsWith("MRI"))
        {
            diseaseImg.sprite = MRI;
        }
        else if (Name.StartsWith("ECG"))
        {
            diseaseImg.sprite = ECG;
        }
        else if (Name.StartsWith("Mitral Valve Repair"))
        {
            diseaseImg.sprite = MitralValveRepair;
        }
        else if (Name.StartsWith("XRay"))
        {
            diseaseImg.sprite = Fracture;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        diseaseImg.color = defaultColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        diseaseImg.color = Color.white;
    }
}
