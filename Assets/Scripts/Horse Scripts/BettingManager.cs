using System;
using System.Collections.Generic;
using UnityEngine;

public class BettingManager : MonoBehaviour
{
    public float playerBalance = 1000f;

    // Struct to hold a single bet's details
    [System.Serializable]
    public struct ActiveBet
    {
        public int horseID;
        public float amount;
        public float odds; // e.g., 5.0 for 5-to-1
    }

    private List<ActiveBet> activeBets = new List<ActiveBet>();

    // 1. Place a bet
    public void PlaceBet(int horseID, float amount, float odds)
    {
        if (amount <= playerBalance)
        {
            playerBalance -= amount;
            activeBets.Add(new ActiveBet { horseID = horseID, amount = amount, odds = odds });
            Debug.Log($"Bet placed on Horse {horseID}: ${amount} at {odds}:1");
        }
        else
        {
            Debug.Log("Insufficient funds!");
        }
    }

    // 2. Process results when the race ends
    public void ProcessRaceResults(int winningHorseID)
    {
        float totalWinnings = 0f;

        foreach (var bet in activeBets)
        {
            if (bet.horseID == winningHorseID)
            {
                // Return original bet + profit (amount * odds)
                float payout = bet.amount * bet.odds;
                totalWinnings += payout;
                Debug.Log($"Winner! Horse {winningHorseID} paid out ${payout}");
            }
        }

        playerBalance += totalWinnings;
        activeBets.Clear(); // Reset for next race
        Debug.Log($"Race Over. New Balance: ${playerBalance}");
    }

    internal void OnRaceFinished(int v)
    {
        throw new NotImplementedException();
    }
}
