using UnityEngine;
using TMPro;

public class BettingManager : MonoBehaviour
{
    [SerializeField] private int raceTimeCost = 30;

    public TMP_InputField betInputField;
    public TMP_Dropdown horseDropdown;
    public TextMeshProUGUI walletDisplay;

    [HideInInspector] public float currentBetAmount;
    [HideInInspector] public string pickedHorseName;

    void Start()
    {
        UpdateWalletUI();
    }

    public void UpdateWalletUI()
    {
        if (Playerinfo.Instance != null)
            walletDisplay.text = "Balance: $" + Playerinfo.Instance.currentBalance;
        else
            walletDisplay.text = "Balance: $0";
    }

    public bool PlaceBet()
    {
        if (Playerinfo.Instance == null)
        {
            Debug.LogWarning("Playerinfo instance missing.");
            return false;
        }

        if (GameProcessManager.Instance == null)
        {
            Debug.LogWarning("GameProcessManager instance missing.");
            return false;
        }

        pickedHorseName = horseDropdown.options[horseDropdown.value].text;

        if (float.TryParse(betInputField.text, out float amount))
        {
            if (amount <= 0)
                return false;

            int wholeAmount = Mathf.RoundToInt(amount);

            if (!Playerinfo.Instance.RemoveMoney(wholeAmount))
            {
                Debug.Log("Not enough money.");
                return false;
            }

            if (!GameProcessManager.Instance.TrySpendTime(raceTimeCost))
            {
                // Refund if there isn't enough time to race
                Playerinfo.Instance.AddMoney(wholeAmount);
                UpdateWalletUI();
                return false;
            }

            currentBetAmount = wholeAmount;

            UpdateWalletUI();
            RefreshSharedPlayerUI();

            return true;
        }

        return false;
    }

    public void AddWinnings(float multiplier)
    {
        int winnings = Mathf.RoundToInt(currentBetAmount * multiplier);

        if (Playerinfo.Instance != null)
        {
            Playerinfo.Instance.AddMoney(winnings);
        }

        UpdateWalletUI();
        RefreshSharedPlayerUI();
    }

    private void RefreshSharedPlayerUI()
    {
        PlayerinfoDisplay display = FindFirstObjectByType<PlayerinfoDisplay>();

        if (display != null)
            display.RefreshDisplay();
    }
}