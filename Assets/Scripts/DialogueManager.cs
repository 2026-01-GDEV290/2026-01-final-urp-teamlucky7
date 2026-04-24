using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    private string[] nameExtra;
    public bool nextSentence;
    private int totalSentences;
    private int currentSentence;

    private Queue<string> sentences;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<string>();
        nextSentence = false;
        totalSentences = 0;
        currentSentence = -1;
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting Conversation with " + dialogue.name);
        nameText.enabled = true;
        dialogueText.enabled = true;
        nameExtra = new string[dialogue.nameExtra.Length];
        Debug.Log("Length of Name Extra: " + nameExtra.Length);
        for(int i = 0; i < nameExtra.Length; i++)
        {
            Debug.Log("Adding " + dialogue.nameExtra[i] + " to Name Extra.");
            nameExtra[i] = dialogue.nameExtra[i];
            Debug.Log("Added " + nameExtra[i] + " to Name Extra");
        }

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            totalSentences++;
        }

        Debug.Log("Current Sentence: " + GetCurrentSentenceNum());

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

        for(int i = 0; i < nameExtra.Length; i++)
        {
            if(i.Equals(currentSentence) && nameExtra != null && nameExtra[i] != null)
            {
                nameText.text = nameExtra[i];
            }
        }

        nextSentence = true;
        string sentence = sentences.Dequeue();
        currentSentence++;
        Debug.Log("Current Sentence: " + GetCurrentSentenceNum());
        dialogueText.text = sentence;
    }

    public void EndDialogue ()
    {
        totalSentences = 0;
        currentSentence = 0;
        nameText.enabled = false;
        dialogueText.enabled = false;
        Debug.Log("End of Conversation");
    }

    public int GetCurrentSentenceNum()
    {
        return currentSentence;
    }

    public int GetTotalSentences()
    {
        return totalSentences;
    }

    public Queue<string> GetSentenceQueue()
    {
        return sentences;
    }

    public bool getNextSentence()
    {
        return nextSentence;
    }
}
