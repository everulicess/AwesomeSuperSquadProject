using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManagerTutorial: MonoBehaviour
{
    public static DialogueManagerTutorial instance;

    public TMP_Text tutorialDialogueText;
    public Button tutorialContinueButton;
    public GameObject tutorialDialoguePrefab;
    public bool tutorialHasTextPrefab;

    private Queue<string> sentences;

    private void Awake()
    {
        tutorialHasTextPrefab = false;
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
        tutorialContinueButton.onClick.AddListener(DisplayNextSentence);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // Clear any previous sentences
        tutorialHasTextPrefab = true;
        
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
        tutorialContinueButton = _button;
        tutorialDialogueText = _text;
        tutorialDialoguePrefab = _dialoguePrefab;
        Debug.Log("tutorialContinueButton = " + tutorialContinueButton);
        Debug.Log("tutorialDialogueText = " + tutorialDialogueText);
        Debug.Log("tutorialDialoguePrefab = " + tutorialDialoguePrefab);
    }

    IEnumerator TypeSentence(string sentence)
    {
        tutorialDialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            tutorialDialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        tutorialHasTextPrefab = false;
        Destroy(tutorialDialoguePrefab);
    }

/*    public void checkForDialogue()
    {
        Debug.LogError(tutorialHasTextPrefab);
        if (tutorialHasTextPrefab)
        {
            Debug.LogError(dialoguePrefab);
            Destroy(dialoguePrefab);
            Debug.LogError(tutorialHasTextPrefab);
            tutorialHasTextPrefab = false;
        }
    }*/
}
