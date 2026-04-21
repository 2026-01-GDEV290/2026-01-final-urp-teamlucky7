using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance;

    public Dictionary<string, CharacterInfo> characters = new Dictionary<string, CharacterInfo>();

    [Header("Assign Sprites in Inspector")]
    public Sprite bullseyeSprite;
    public Sprite fortuneSprite;
    public Sprite jackSprite;
    public Sprite larrySprite;
    public Sprite spyglassSprite;
    public Sprite strangulaSprite;
    public Sprite alanSprite;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        InitializeCharacters();
    }

    void InitializeCharacters()
    {
        characters.Add("Bullseye", new CharacterInfo(0, "Bullseye", bullseyeSprite));
        characters.Add("Fortune", new CharacterInfo(1, "Fortune", fortuneSprite));
        characters.Add("Jack", new CharacterInfo(2, "Jack", jackSprite));
        characters.Add("Larry", new CharacterInfo(3, "Larry", larrySprite));
        characters.Add("Spyglass", new CharacterInfo(4, "Spyglass", spyglassSprite));
        characters.Add("Strangula", new CharacterInfo(5, "Strangula", strangulaSprite));
        characters.Add("Alan Sluggard", new CharacterInfo(6, "Alan Sluggard", alanSprite));
    }

    public CharacterInfo GetCharacter(string characterKey)
    {
        if (characters.TryGetValue(characterKey, out CharacterInfo info))
            return info;

        Debug.LogWarning("Character not found: " + characterKey);
        return null;
    }
}