using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerinfoDisplay : MonoBehaviour
{
    [SerializeField] private Image portraitImage;
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text balanceText;

    private void Start()
    {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        if (Playerinfo.Instance == null)
        {
            Debug.LogWarning("Playerinfo instance not found.");
            return;
        }

        CharacterInfo selected = Playerinfo.Instance.selectedCharacter;

        if (selected != null)
        {
            if (portraitImage != null)
                portraitImage.sprite = selected.characterPortrait;

            if (characterNameText != null)
                characterNameText.text = selected.characterName;
        }

        if (balanceText != null)
            balanceText.text = "$" + Playerinfo.Instance.currentBalance;
    }
}