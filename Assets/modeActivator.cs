using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class modeActivator : MonoBehaviour
{
    [SerializeField] public List<AnatomyMode> AnatomyModes;
    public void Start()
    {
        InitializeModes();
    }

    public void InitializeModes()
    {
        foreach (AnatomyMode mode in AnatomyModes)
        {
            mode.InitializeMode();
            mode.ModeActivated += DeActivateModes;
        }
    }
    public void DeActivateModes()
    {
        
        foreach (AnatomyMode mode in AnatomyModes)
        {
            mode.DeActivateMode();
        }
        
    }

    [System.Serializable]
    public class AnatomyMode
    {
        [SerializeField]
        public List<AnatomySystem> AnatomySystems;
        public ModeButton modeButton;
        public delegate void ModeActivatedEvent();
        public event ModeActivatedEvent ModeActivated;

        public void InitializeMode() {
            modeButton.ToggleMode += ToggleMode;
            Debug.Log("Event Initialized");
        }

        public void ToggleMode()
        {
            ModeActivated();
            ActivateMode();
        }

        public void ActivateMode()
        {

            foreach (AnatomySystem system in AnatomySystems)
            {
                system.gameObject.SetActive(true);
            }
        }

        public void DeActivateMode()
        {
            foreach (AnatomySystem system in AnatomySystems)
            {
                system.gameObject.SetActive(false);
            }
        }
    }
}