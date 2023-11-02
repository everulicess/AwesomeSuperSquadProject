using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        // Call Dialogue Manager to start the dialogue
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
