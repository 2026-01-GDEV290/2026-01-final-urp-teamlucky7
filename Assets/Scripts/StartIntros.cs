using UnityEngine;

public class StartIntros : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private CutsceneManager cutsceneManager;

    public string testPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (Playerinfo.Instance.selectedCharacter.characterName)
        {
            case "Bullseye":
                dialogueManager.GetDialogueTrigger(0).TriggerDialogue();
                cutsceneManager.PlayCutscene(0);
                break;
            case "Jack":
                dialogueManager.GetDialogueTrigger(1).TriggerDialogue();
                cutsceneManager.PlayCutscene(1);
                break;
            case "Spyglass":
                dialogueManager.GetDialogueTrigger(2).TriggerDialogue();
                cutsceneManager.PlayCutscene(2);
                break;
            case "Fortune":
                dialogueManager.GetDialogueTrigger(3).TriggerDialogue();
                cutsceneManager.PlayCutscene(3);
                break;
            case "Strangula":
                dialogueManager.GetDialogueTrigger(4).TriggerDialogue();
                cutsceneManager.PlayCutscene(4);
                break;
            case "Alan Slugger":
                dialogueManager.GetDialogueTrigger(5).TriggerDialogue();
                cutsceneManager.PlayCutscene(5);
                break;
            case "Larry":
                dialogueManager.GetDialogueTrigger(6).TriggerDialogue();
                cutsceneManager.PlayCutscene(6);
                break;
        }

        //switch (testPlayer)
        //{
        //    case "Bullseye":
        //        dialogueManager.GetDialogueTrigger(0).TriggerDialogue();
        //        cutsceneManager.PlayCutscene(0);
        //        break;
        //    case "Jack":
        //        dialogueManager.GetDialogueTrigger(1).TriggerDialogue();
        //        cutsceneManager.PlayCutscene(1);
        //        break;
        //    case "Spyglass":
        //        dialogueManager.GetDialogueTrigger(2).TriggerDialogue();
        //        cutsceneManager.PlayCutscene(2);
        //        break;
        //    case "Fortune":
        //        dialogueManager.GetDialogueTrigger(3).TriggerDialogue();
        //        cutsceneManager.PlayCutscene(3);
        //        break;
        //    case "Strangula":
        //        dialogueManager.GetDialogueTrigger(4).TriggerDialogue();
        //        cutsceneManager.PlayCutscene(4);
        //        break;
        //    case "Alan":
        //        dialogueManager.GetDialogueTrigger(5).TriggerDialogue();
        //        cutsceneManager.PlayCutscene(5);
        //        break;
        //    case "Larry":
        //        dialogueManager.GetDialogueTrigger(6).TriggerDialogue();
        //        cutsceneManager.PlayCutscene(6);
        //        break;
        //}
    }

}
