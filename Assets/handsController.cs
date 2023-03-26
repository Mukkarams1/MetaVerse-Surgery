using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class handsController : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private string controllerName;
    [SerializeField] private string actionNameTrigger;
    [SerializeField] private string actionNameGrip;





    private InputActionMap actionMap;
    private InputAction inputactionTrigger;
    private InputAction inputactionGrip;

    private Animator handAnimator;


    // Start is called before the first frame update
    void Awake()
    {
        //get the actions
        actionMap = actionAsset.FindActionMap(controllerName);
        inputactionGrip = actionMap.FindAction(actionNameGrip);
        inputactionTrigger = actionMap.FindAction(actionNameTrigger);

        //get the animator
        handAnimator = GetComponent<Animator>();
    }


    private void OnEnable()
    {
        inputactionGrip.Enable();
        inputactionTrigger.Enable();

    }

    private void OnDisable()
    {
        inputactionGrip.Disable();
        inputactionTrigger.Disable();

    }

    // Update is called once per frame
    void Update()
    {
        var gripValue = inputactionGrip.ReadValue<float>();
        var triggerValue = inputactionTrigger.ReadValue<float>();

        handAnimator.SetFloat("Grip", gripValue);
        handAnimator.SetFloat("Trigger", triggerValue);
    }
}
