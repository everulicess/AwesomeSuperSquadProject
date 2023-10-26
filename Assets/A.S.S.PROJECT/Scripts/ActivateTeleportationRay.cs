using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField] GameObject rightTeleportation;

    [SerializeField] InputActionProperty rightActivate;

    [SerializeField] InputActionProperty rightCancel;

    [SerializeField] GameObject rightGrabRay;

    [SerializeField] XRDirectInteractor rightDirectGrab;

    [SerializeField] XRRayInteractor rightRay;
    // Update is called once per frame
    void Update()
    {
        bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool rightValid);
        rightTeleportation.SetActive(isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);

        rightGrabRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);
    }
}
