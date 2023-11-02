using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public TMP_Text dialogueText;
    public Button continueButton;
    public GameObject dialoguePrefab;
    public bool hasTextPrefab;

    private Queue<string> sentences;

    private void Awake()
    {
        hasTextPrefab = false;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one instance
        }
    }

    public void ConnectDialoguePrefab()
    {
        sentences = new Queue<string>();
        continueButton.onClick.AddListener(DisplayNextSentence);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // Clear any previous sentences
        hasTextPrefab = true;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void LinkTextAndButton(Button _button, TMP_Text _text, GameObject _dialoguePrefab)
    {
        continueButton = _button;
        dialogueText = _text;
        dialoguePrefab = _dialoguePrefab;
        Debug.LogError(continueButton);
        Debug.LogError(dialogueText);
        Debug.LogError(dialoguePrefab);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        hasTextPrefab = false;
        Destroy(dialoguePrefab);
    }

/*    public void checkForDialogue()
    {
        Debug.LogError(hasTextPrefab);
        if (hasTextPrefab)
        {
            Debug.LogError(dialoguePrefab);
            Destroy(dialoguePrefab);
            Debug.LogError(hasTextPrefab);
            hasTextPrefab = false;
        }
    }*/
}
