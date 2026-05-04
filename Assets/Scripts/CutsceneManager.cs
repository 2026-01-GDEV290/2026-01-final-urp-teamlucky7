using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    }

    public void CreateCutscene(Image[] scene, int[] trigger)
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

    public void PlayCutscene(int cutsceneNum)
    {
        StartCoroutine("ShowCutscene", cutsceneNum);
    }

    public IEnumerator ShowCutscene(int cutsceneNum)
    {
        Debug.Log("Attempting to show cutscene " +  cutsceneNum);
        for (int i = 0; i < cutsceneArray.Length; i++)
        {
            if (cutsceneArray[i].enabled && i.Equals(cutsceneNum) == false)
            {
                Debug.Log("Hiding Cutscene " + i);
                for (int j = 0; j < cutsceneArray[i].GetSceneArray().Length; j++)
                {
                    cutsceneArray[i].GetScene(j).enabled = false;
                }
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
            for (int i = 0; i < cutsceneArray[cutsceneNum].GetSceneArray().Length; i++) //iterate through the specified cutscene to hide all but the first scene
            {
                if(i > 0)
                {
                    cutsceneArray[cutsceneNum].GetScene(i).enabled = false;
                }
            }

                for (int i = 0; i < cutsceneArray[cutsceneNum].GetSceneArray().Length; i++) //iterate through the specified cutscene to allow all cutscenes to be enabled, in order
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
                yield return new WaitUntil(() => dialogue.GetCurrentSentenceNum().Equals(cutsceneArray[cutsceneNum].GetTrigger()[i]));
                Debug.Log("Show next scene.");
                cutsceneArray[cutsceneNum].NextScene();
            }
        }
    }


    public void PlayIntroCutscene(int cutsceneNum)
    {
        StartCoroutine("ShowINTROCutscene", cutsceneNum);
    }
    
    public IEnumerator ShowINTROCutscene(int cutsceneNum)
    {
        Debug.Log("Attempting to show cutscene " +  cutsceneNum);
        for (int i = 0; i < cutsceneArray.Length; i++)
        {
            if (cutsceneArray[i].enabled && i.Equals(cutsceneNum) == false)
            {
                Debug.Log("Hiding Cutscene " + i);
                for (int j = 0; j < cutsceneArray[i].GetSceneArray().Length; j++)
                {
                    cutsceneArray[i].GetScene(j).enabled = false;
                }
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
            for (int i = 0; i < cutsceneArray[cutsceneNum].GetSceneArray().Length; i++) //iterate through the specified cutscene to hide all but the first scene
            {
                if(i > 0)
                {
                    cutsceneArray[cutsceneNum].GetScene(i).enabled = false;
                }
            }

            for (int i = 0; i < cutsceneArray[cutsceneNum].GetSceneArray().Length; i++)
            {
                Debug.Log("Scene " + i);

                if (!dialogue.GetCurrentSentenceNum().Equals(cutsceneArray[cutsceneNum].GetTrigger()[i]))
                {
                    if (cutsceneArray[cutsceneNum].IsHidden(sceneNum))
                    {
                        Debug.Log("Cutscene " + cutsceneNum + " hidden. Showing Cutscene " + cutsceneNum);
                        cutsceneArray[cutsceneNum].ShowScene(sceneNum);
                    }
                }

                yield return new WaitUntil(() => dialogue.GetCurrentSentenceNum().Equals(cutsceneArray[cutsceneNum].GetTrigger()[i]));

                Debug.Log("Show next scene.");
                cutsceneArray[cutsceneNum].NextScene();
            }

            // cutscene is finished
            SceneManager.LoadScene("TitleScreen");
        }
    }


// cutscene is finished
//SceneManager.LoadScene("TitleScreen");
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
