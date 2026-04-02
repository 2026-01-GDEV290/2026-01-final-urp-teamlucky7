using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    private Image[] cutsceneArray;

    [SerializeField]
    private bool showNextScene = false;
    [SerializeField]
    private DialogueManager dialogue;
    [SerializeField]
    private DialogueTrigger dialogueTrigger;

    public void Start()
    {
        dialogueTrigger.TriggerDialogue();
    }

    public void Update()
    {
        if (dialogue.getNextSentence() == true && showNextScene == false)
        {
            showNextScene = true;
        }
    }

    public void showCutscene(int[] index)
    {
        for(int i = 0; i < index.Length; i++)
        {
            while (showNextScene == false)
            {
                cutsceneArray[i].enabled = true;
                if(dialogue.getNextSentence() == true)
                {
                    cutsceneArray[i].enabled = false;
                    showNextScene = true;
                }
            }
            if (showNextScene == true) {
                cutsceneArray[i].enabled = false;
            }
        }
    }
}
