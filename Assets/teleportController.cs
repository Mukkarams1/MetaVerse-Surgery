using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class teleportController : MonoBehaviour
{

    public GameObject baseControllerGameObject;
    public GameObject teleportationGameObject;

    public InputActionReference teleportationActivationReference;

    [Space]

    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;

    private void Start()
    {
        teleportationActivationReference.action.performed += TeleportModeActivate;
        teleportationActivationReference.action.performed += TeleportModeCancel;
    }


    private void TeleportModeCancel(InputAction.CallbackContext obj)
    {
        Invoke("DeactivateTeleporter", 0.1f);
    }

    void DeactivateTeleporter() => onTeleportCancel.Invoke();

    private void TeleportModeActivate(InputAction.CallbackContext obj) => onTeleportActivate.Invoke();
    
}
