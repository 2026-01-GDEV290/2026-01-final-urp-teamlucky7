using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public bool nextSentence;

    private Queue<string> sentences;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<string>();
        nextSentence = false;
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting Conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        nextSentence = false;
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        nextSentence = true;
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue ()
    {
        Debug.Log("End of Conversation");
    }

    public bool getNextSentence()
    {
        return nextSentence;
    }
}
