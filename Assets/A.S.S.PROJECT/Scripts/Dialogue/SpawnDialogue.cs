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
        Debug.Log("Spawn Textbox");
        DialogueManager.instance.hasTextPrefab = true;
        CreateDialogue();
        /*DialogueManager.instance.checkForDialogue();*/
/*        GameObject dialogueManager = GameObject.Find("DialogueManager");
        DialogueManager dm = dialogueManager.GetComponent<DialogueManager>();
        dm.hasTextPrefab = true;*/
    }

    public void TriggerDialogue()
    {
        Debug.Log("Trigger Dialogue");
        // Call Dialogue Manager to start the dialogue
        DialogueManager.instance.StartDialogue(dialogue);
    }

    public void CreateDialogue()
    {
        Debug.Log("Spawning TextBox");
        Instantiate(dialoguePrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
