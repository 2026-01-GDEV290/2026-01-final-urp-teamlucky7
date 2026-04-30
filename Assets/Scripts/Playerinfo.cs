using UnityEngine;

public class Playerinfo : MonoBehaviour
{
    public static Playerinfo Instance;

    [Header("Current Player Data")]
    public CharacterInfo selectedCharacter;
    public int currentBalance = 1000;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCharacterByName(string characterKey)
    {
        if (Character.Instance == null)
        {
            Debug.LogWarning("Character database is missing.");
            return;
        }

        CharacterInfo info = Character.Instance.GetCharacter(characterKey);

        if (info != null)
        {
            selectedCharacter = info;
            Debug.Log("Selected character: " + selectedCharacter.characterName);
        }
    }

    public void SetBalance(int amount)
    {
        currentBalance = amount;
    }

    public void AddMoney(int amount)
    {
        currentBalance += amount;
    }

    public bool RemoveMoney(int amount)
    {
        if (currentBalance < amount)
            return false;

        currentBalance -= amount;
        return true;
    }


}