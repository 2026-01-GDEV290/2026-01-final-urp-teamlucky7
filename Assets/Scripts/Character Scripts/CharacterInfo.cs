using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterInfo
{
    public int characterID;
    public string characterName;
    public Sprite characterPortrait;

    public CharacterInfo(int id, string name, Sprite portrait)
    {
        characterID = id;
        characterName = name;
        characterPortrait = portrait;
    }
}