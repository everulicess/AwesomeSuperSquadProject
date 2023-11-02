using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDialogue : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject dialoguePrefab;

    [Header("Attributes")]
    [SerializeField] private Dialogue dialogue;

    private DialogueManager dm;

    private void Awake()
    {
        Debug.LogError("Awake Textbox");
        DialogueManager.instance.hasTextPrefab = true;
        /*DialogueManager.instance.checkForDialogue();*/
/*        GameObject dialogueManager = GameObject.Find("DialogueManager");
        DialogueManager dm = dialogueManager.GetComponent<DialogueManager>();
        dm.hasTextPrefab = true;*/
    }

    public void TriggerDialogue()
    {
        Debug.LogError("Trigger Effie Dialogue");
        // Call Dialogue Manager to start the dialogue
        DialogueManager.instance.StartDialogue(dialogue);
    }

    public void CreateDialogue()
    {
        Debug.LogError("Spawning Effie TextBox");
        Instantiate(dialoguePrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
