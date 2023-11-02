using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueConnect : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Dialogue dialogue;

    private Canvas dialogueCanvas;
    private GameObject dialoguePrefab;
    
    private void Awake()
    {
        dialoguePrefab = gameObject;
        GameObject dialogueManager = GameObject.Find("DialogueManager");
        DialogueManager dm = dialogueManager.GetComponent<DialogueManager>();
        dm.LinkTextAndButton(continueButton, dialogueText, dialoguePrefab);
        dm.ConnectDialoguePrefab();
        dialogueCanvas = GameObject.Find("DialogueCanvas").GetComponent<Canvas>();
    }

    private void Start()
    {
        if (dialogueCanvas != null)
        {
            this.transform.SetParent(dialogueCanvas.transform, false);
        }
        else
        {
            Debug.LogError("dialogueCanvas is not found. Make sure you have a GameObject named 'DialogueCanvas' in your scene.");
        }
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        // Call Dialogue Manager to start the dialogue
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
