using UnityEngine;
using UnityEngine.UI;

public class characterselect : MonoBehaviour
{

   public Button confirmbutton;
   private bool characterpicked = false;
//disables lets roll button until character is selected
void Update()
 {
   if(characterpicked == false){
      confirmbutton.interactable = false;
      Debug.Log($"NO CHARACTER SELECTED");
   }
   else
   {
      confirmbutton.interactable = true;
   }
 }
 public void SelectBullseye()
 {
    Playerinfo.Instance.SetCharacterByName("Bullseye");
    characterpicked = true;
 }

 public void SelectFortune()
 {
    Playerinfo.Instance.SetCharacterByName("Fortune");
    characterpicked = true;
 }

 public void SelectJack()
 {
    Playerinfo.Instance.SetCharacterByName("Jack");
    characterpicked = true;
 }
 public void SelectLarry()
 {
    Playerinfo.Instance.SetCharacterByName("Larry");
    characterpicked = true;
 }
  public void SelectSpyglass()
 {
    Playerinfo.Instance.SetCharacterByName("Spyglass");
    characterpicked = true;
 }
    public void SelectStrangula()
 {
    Playerinfo.Instance.SetCharacterByName("Strangula");
    characterpicked = true;
 }
     public void SelectAlan()
 {
    Playerinfo.Instance.SetCharacterByName("Alan Sluggard");
    characterpicked = true;
 }
}
