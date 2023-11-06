using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ApprovalButton : MonoBehaviour
{
    MicrochipScanner microchipscanner;
    GameManager gM;
    private void Awake()
    {
        microchipscanner = GameObject.FindAnyObjectByType<MicrochipScanner>();
        gM = GameObject.FindObjectOfType<GameManager>();
    }
    public void AcceptNPC()
    {
        if (gM.requirementsClicked)
        {
            GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCStateMachine>().approved = true;
            microchipscanner.hasDecided = true;
            gM.decisionMade = true;
            gM.tutorialfinished = true;
            Debug.Log("ACCEPTED");
        }
        
    }
    public void RejectNPC()
    {
        if (gM.requirementsClicked)
        {
            GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCStateMachine>().rejected = true;
            microchipscanner.hasDecided = true;
            gM.decisionMade = true;
            Debug.Log("REJECTED");
            gM.tutorialfinished = true;
        }
        
    }
    public void DetainNPC()
    {
        if (gM.requirementsClicked)
        {
            GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCStateMachine>().detained = true;
            microchipscanner.hasDecided = true;
            Debug.Log("DETAINED");
            gM.tutorialfinished = true;
        }
       
    }
}
