using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class BettingManager : MonoBehaviour
{
    public float playerBalance = 1000f;
    public Text balanceText;
    public InputField betAmountInput;
    private int selectedHorse = -1;
    private float currentBet = 0f;

    // Call this when selecting a horse
    public void SelectHorse(int horseID)
    {
        selectedHorse = horseID;
    }

    // Call this from "Place Bet" button
    public void PlaceBet()
    {
        float.TryParse(betAmountInput.text, out currentBet);
        if (currentBet <= playerBalance && selectedHorse != -1)
        {
            playerBalance -= currentBet;
            UpdateUI();
            Debug.Log("Bet placed on horse: " + selectedHorse);
        }
    }

    public void OnRaceFinished(int winnerID, float odds)
    {
        if (winnerID == selectedHorse)
        {
            playerBalance += (currentBet * odds);
        }
        selectedHorse = -1;
        UpdateUI();
    }

    void UpdateUI()
    {
        balanceText.text = "Balance: $" + playerBalance.ToString();
    }

    internal void OnRaceFinished(int v)
    {
        throw new NotImplementedException();
    }
}
