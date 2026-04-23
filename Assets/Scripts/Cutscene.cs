using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    [SerializeField]
    private Sprite[] scenes;
    [SerializeField]
    private int[] triggerOnSentenceNum;
    [SerializeField]
    private SpriteRenderer[] spriteRenderers;

    public Cutscene(Sprite[] setscenes, int[] settrigger)
    {
        this.triggerOnSentenceNum = settrigger;
        this.scenes = setscenes;
    }

    public Sprite[] GetSceneArray()
    {
        return scenes;
    }

    //returns a specific scene @ iterator location
    public Sprite GetScene(int iterator)
    {
        if (scenes != null)
        {
            return scenes[iterator];
        }
        else
        {
            return null;
        }
    }

    //gets the iterator of the current active scene. stops once it finds the first active and enabled image.
    public int GetSceneIterator()
    {
        int returnIterator = 0;
        if (scenes != null)
        {
            for(int i = 0; i < scenes.Length - 1; i++)
            {
                if (spriteRenderers[i].enabled == true)
                {
                    returnIterator = i;
                    break;
                }
            }
        }

        return returnIterator;
    }

    //returns the game object set as the trigger
    public int[] GetTrigger() { 
        return triggerOnSentenceNum;
    }

    //sets scene @ specific iterator location
    public void SetScene(int iterator, Sprite scene)
    {
        if (scenes != null)
        {
            scenes[iterator] = scene;
        }
    }

    public void ShowScene(int sceneNum)
    {
        spriteRenderers[sceneNum].enabled = true;
    }

    public bool IsHidden(int sceneNum)
    {
        return spriteRenderers[sceneNum].enabled;
    }

    //sets the trigger for the cutscene
    public void SetTrigger(int[] newTrigger)
    {
        triggerOnSentenceNum = newTrigger;
    }

    public void AddTrigger(int newTrigger)
    {
        triggerOnSentenceNum[triggerOnSentenceNum.Length] = newTrigger;
    }

    public void NextScene()
    {
        int currentScene = GetSceneIterator();
        spriteRenderers[currentScene].enabled = false;
        if(currentScene + 1 < scenes.Length)
        {
            spriteRenderers[currentScene + 1].enabled = true;
        }
    }
}
