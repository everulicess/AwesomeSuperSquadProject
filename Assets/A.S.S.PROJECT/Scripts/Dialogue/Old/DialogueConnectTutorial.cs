using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueConnectTutorial: MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Dialogue dialogue;

    private Canvas tabletTutorialUI;
    private GameObject dialoguePrefab;
    
    private void Awake()
    {
        dialoguePrefab = gameObject;
        GameObject dialogueManager = GameObject.Find("DialogueManager");
        DialogueManager dm = dialogueManager.GetComponent<DialogueManager>();
        dm.LinkTextAndButton(continueButton, dialogueText, dialoguePrefab);
        dm.ConnectDialoguePrefab();
        tabletTutorialUI = GameObject.Find("TabletTutorialUI").GetComponent<Canvas>();
    }

    private void Start()
    {
        if (tabletTutorialUI != null)
        {
            this.transform.SetParent(tabletTutorialUI.transform, false);
        }
        else
        {
            Debug.LogError("TabletTutorialUI is not found. Make sure you have a GameObject named 'TabletTutorialUI' in your scene.");
        }
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        // Call Dialogue Manager to start the dialogue
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
