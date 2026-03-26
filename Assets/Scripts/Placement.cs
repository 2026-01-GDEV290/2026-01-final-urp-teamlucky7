using UnityEngine;
using System.Collections.Generic;
using TMPro; // For UI display

public class Placement : MonoBehaviour
{
    public int totalLaps = 3;
    private List<HorseRank> finishedHorses = new List<HorseRank>();
    public TMP_Text leaderboardText;
    internal bool hasFinished;
    internal int lapsCompleted;

    public void OnHorseFinish(HorseRank horse)
    {
        if (!finishedHorses.Contains(horse))
        {
            horse.hasFinished = true;
            finishedHorses.Add(horse);

            // Stop the horse's movement script
            horse.GetComponent<HorseMovement>().enabled = false;

            UpdateLeaderboardUI();
        }
    }

    void UpdateLeaderboardUI()
    {
        string results = "FINAL PLACEMENT:\n";
        for (int i = 0; i < finishedHorses.Count; i++)
        {
            results += $"{i + 1}. {finishedHorses[i].name}\n";
        }
        leaderboardText.text = results;
    }
}