using UnityEngine;
using TMPro;

public class BettingManager : MonoBehaviour
{
    public float walletBalance = 1000f;
    public TMP_InputField betInputField;
    public TMP_Dropdown horseDropdown; // Drag your Dropdown here
    public TextMeshProUGUI walletDisplay;

    [HideInInspector] public float currentBetAmount;
    [HideInInspector] public string pickedHorseName;

    void Start()
    {
        UpdateWalletUI();
    }

    public void UpdateWalletUI()
    {
        walletDisplay.text = "Balance: $" + walletBalance;
    }

    public bool PlaceBet()
    {
        // 1. Get the horse name currently selected in the dropdown
        pickedHorseName = horseDropdown.options[horseDropdown.value].text;

        // 2. Validate the money
        if (float.TryParse(betInputField.text, out float amount))
        {
            if (amount > 0 && amount <= walletBalance)
            {
                currentBetAmount = amount;
                walletBalance -= amount;
                UpdateWalletUI();
                return true;
            }
        }
        return false;
    }

    public void AddWinnings(float multiplier)
    {
        walletBalance += (currentBetAmount * multiplier);
        UpdateWalletUI();
    }
}
