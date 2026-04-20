using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    private Cutscene[] cutsceneArray;


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

    public void createCutscene(Image[] scene, GameObject trigger)
    {
        Cutscene newCutscene = new Cutscene(scene, trigger);
    }

    public void addCutscene(Cutscene addedScene)
    {
        for(int i = 0; i < cutsceneArray.Length - 1; i++)
        {
            if(cutsceneArray[i] == null)
            {
                cutsceneArray[i] = addedScene;
                break;
            }
        }
    }

    public void showCutscene(int iterator)
    {
        for (int i = 0; i < cutsceneArray.Length - 1; i++)
        {
            if (cutsceneArray[i].isActiveAndEnabled && i.Equals(iterator) == false)
            {
                cutsceneArray[i].enabled = false;
            }
        }

        if (cutsceneArray[iterator].isActiveAndEnabled == false)
        {
            cutsceneArray[iterator].enabled = true;
        }
    }

    public void SetCutsceneTrigger(int iterator, GameObject settrigger)
    {

    }

    public void showCutsceneInOrder(int[] index)
    {
        for(int i = 0; i < index.Length; i++)
        {
            while (showNextScene == false)
            {
                cutsceneArray[i].GetScene(i).enabled = true;
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
