using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    [SerializeField]
    private Image[] scenes;
    [SerializeField]
    private GameObject trigger;

    public Cutscene(Image[] setscenes, GameObject settrigger)
    {
        this.trigger = settrigger;
        this.scenes = setscenes;
    }

    //returns a specific scene @ iterator location
    public Image GetScene(int iterator)
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

    //returns the game object set as the trigger
    public GameObject GetTrigger() { 
        return trigger;
    }

    //sets scene @ specific iterator location
    public void SetScene(int iterator, Image scene)
    {
        if (scenes != null)
        {
            scenes[iterator] = scene;
        }
    }

    //sets the trigger for the cutscene
    public void SetTrigger(GameObject newTrigger)
    {
        if (trigger != null)
        {
            trigger = newTrigger;
        }
    }
}
