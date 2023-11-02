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

    private Queue<string> sentences;

    private void Awake()
    {
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
        Debug.Log("1");
        continueButton = _button;
        Debug.Log("2");
        dialogueText = _text;
        dialoguePrefab = _dialoguePrefab;
        Debug.Log(continueButton);
        Debug.Log(dialogueText);
        Debug.Log(dialoguePrefab);
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
        Destroy(dialoguePrefab);
    }
}
