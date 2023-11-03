using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField] GameObject rightTeleportation;
    [SerializeField] GameObject leftTeleportation;

    [SerializeField] InputActionProperty rightActivate;
    [SerializeField] InputActionProperty leftActivate;

    [SerializeField] InputActionProperty rightCancel;
    [SerializeField] InputActionProperty leftCancel;

    [SerializeField] GameObject rightGrabRay;
    [SerializeField] GameObject leftGrabRay;

    [SerializeField] XRDirectInteractor rightDirectGrab;
    [SerializeField] XRDirectInteractor leftDirectGrab;

    [SerializeField] XRRayInteractor rightRay;
    [SerializeField] XRRayInteractor leftRay;
    // Update is called once per frame
    void Update()
    {
        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);
        
        bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool rightValid);

        rightTeleportation.SetActive(isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() >= 0.1f);
        leftTeleportation.SetActive(isLeftRayHovering && leftCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() >= 0.1f);

        rightGrabRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);
        leftGrabRay.SetActive(leftDirectGrab.interactablesSelected.Count == 0);
    }
}
