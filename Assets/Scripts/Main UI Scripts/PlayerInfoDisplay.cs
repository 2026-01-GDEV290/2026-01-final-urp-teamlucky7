using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerinfoDisplay : MonoBehaviour
{
    [SerializeField] private Image portraitImage;
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text balanceText;

    [Header("Casino Time UI")]
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text timeRemainingText;

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

        if (CasinoTimeManager.Instance != null)
        {
            if (dayText != null)
                dayText.text = "Day " + CasinoTimeManager.Instance.CurrentDay;

            if (timeText != null)
                timeText.text = "Time: " + CasinoTimeManager.Instance.GetFormattedTime();

            if (timeRemainingText != null)
                timeRemainingText.text = "Time Left: " + CasinoTimeManager.Instance.GetFormattedRemainingTime();
        }
    }
}