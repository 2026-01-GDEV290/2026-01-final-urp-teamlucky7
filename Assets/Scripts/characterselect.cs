using UnityEngine;

public class characterselect : MonoBehaviour
{
 public void SelectBullseye()
 {
    Playerinfo.Instance.SetCharacterByName("Bullseye");
 }

 public void SelectFortune()
 {
    Playerinfo.Instance.SetCharacterByName("Fortune");
 }

 public void SelectJack()
 {
    Playerinfo.Instance.SetCharacterByName("Jack");
 }
 public void SelectLarry()
 {
    Playerinfo.Instance.SetCharacterByName("Larry");
 }
  public void SelectSpyglass()
 {
    Playerinfo.Instance.SetCharacterByName("Spyglass");
 }
    public void SelectStrangula()
 {
    Playerinfo.Instance.SetCharacterByName("Strangula");
 }
     public void SelectAlan()
 {
    Playerinfo.Instance.SetCharacterByName("AlanSluggard");
 }
}
