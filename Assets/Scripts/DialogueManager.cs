using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Button continueButton;

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
            if(i.Equals(currentSentence) && nameExtra != null && nameExtra[i].Length > 0)
            {
                nameText.text = nameExtra[i];
            } else
            {
                nameText.text = nameText.text;
            }
        }

        nextSentence = true;
        string sentence = sentences.Dequeue();
        currentSentence++;
        Debug.Log("Current Sentence: " + GetCurrentSentenceNum());
        dialogueText.text = sentence;
    }

    public bool EndDialogue ()
    {
        totalSentences = 0;
        currentSentence = 0;
        nameText.enabled = false;
        dialogueText.enabled = false;
        continueButton.enabled = false;
        continueButton.GetComponent<Image>().enabled = false;
        continueButton.GetComponentInChildren<TextMeshProUGUI>().enabled = false;

        if (nameText.GetComponentInParent<Image>().enabled)
        {
            nameText.GetComponentInParent<Image>().enabled = false;
        }

        Debug.Log("End of Conversation");

        return true;
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
