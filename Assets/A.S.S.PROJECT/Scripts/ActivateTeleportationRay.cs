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

    [SerializeField] XRRayInteractor rightRay;
    [SerializeField] XRRayInteractor leftRay;
    // Update is called once per frame
    void Update()
    {
        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);

        leftTeleportation.SetActive(isLeftRayHovering && leftCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f);

        bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool rightValid);

        rightTeleportation.SetActive(isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);

        //Debug.LogError($"left hand ray{isLeftRayHovering}");
        //Debug.LogError($"right hand ray{isRightRayHovering}");
    }
}
