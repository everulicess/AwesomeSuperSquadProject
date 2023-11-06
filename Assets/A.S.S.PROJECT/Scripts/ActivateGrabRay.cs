using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    [SerializeField] GameObject rightGrabRay;
    [SerializeField] GameObject leftGrabRay;

    [SerializeField] XRDirectInteractor rightDirectGrab;
    [SerializeField] XRDirectInteractor leftDirectGrab;

    // Update is called once per frame
    void Update()
    {

        rightGrabRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);
        leftGrabRay.SetActive(leftDirectGrab.interactablesSelected.Count == 0);
    }
}
