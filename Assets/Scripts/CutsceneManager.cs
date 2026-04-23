using System;
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


    public void Start()
    {

    }

    public void Update()
    {
        if (dialogue.getNextSentence() == true && showNextScene == false)
        {
            showNextScene = true;
        }
    }

    public void CreateCutscene(Sprite[] scene, int[] trigger)
    {
        Cutscene newCutscene = new Cutscene(scene, trigger);
    }

    public void AddCutscene(Cutscene addedScene)
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

    public void ShowCutscene(int cutsceneNum)
    {
        Debug.Log("Attempting to show cutscene " +  cutsceneNum);
        for (int i = 0; i < cutsceneArray.Length; i++)
        {
            if (cutsceneArray[i].enabled && i.Equals(cutsceneNum) == false)
            {
                Debug.Log("Hiding Cutscene " + i);
                cutsceneArray[i].enabled = false;
            } else if(i.Equals(cutsceneNum) == true)
            {
                Debug.Log("Cutscene " + i + " is cutscene num");
            }
            else 
            {
                Debug.Log("Cutscene " + i + " is already hidden.");
            }
        }

        int sceneNum = 0;

        if (cutsceneArray[cutsceneNum].enabled == true)
        {
            Debug.Log("Cutscene Active and Enabled");
            for (int i = 0; i < cutsceneArray[cutsceneNum].GetSceneArray().Length; i++) //iterate through the specified cutscene to allow all cutscenes to be enabled
            {
                Debug.Log("Scene " + i);
                if (!dialogue.GetCurrentSentenceNum().Equals(cutsceneArray[cutsceneNum].GetTrigger()[i])) //check to see if the current number sentence matches with the int to trigger the next scene
                {
                    if (cutsceneArray[cutsceneNum].IsHidden(sceneNum))
                    {
                        Debug.Log("Cutscene " + cutsceneNum + " hidden. Showing Cutscene " + cutsceneNum);
                        cutsceneArray[cutsceneNum].ShowScene(sceneNum);
                    }
                    
                }

                Debug.Log("Show next scene.");
                cutsceneArray[cutsceneNum].NextScene();
            }
        }
    }

    //public void ShowCutsceneInOrder(int[] index)
    //{
    //    for(int i = 0; i < index.Length; i++)
    //    {
    //        while (showNextScene == false)
    //        {
    //            cutsceneArray[i].GetScene(i).enabled = true;
    //            if (dialogue.GetCurrentSentenceNum().Equals(cutsceneArray[]) )
    //            {
    //                cutsceneArray[i].enabled = false;
    //                showNextScene = true;
    //            }
    //        }
    //        if (showNextScene == true) {
    //            cutsceneArray[i].enabled = false;
    //        }
    //    }
    //}
}
