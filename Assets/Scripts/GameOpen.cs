using UnityEngine;

public class GameOpen : MonoBehaviour
{
    public CutsceneManager cutsceneManager;
    public DialogueTrigger dialogueTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cutsceneManager.PlayIntroCutscene(0);
        dialogueTrigger.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
