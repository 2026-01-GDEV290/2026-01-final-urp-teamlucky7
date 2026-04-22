using UnityEngine;
using System.Collections.Generic;

public class HorseRaceManager : MonoBehaviour
{
    // List to store horses in the order they finish
    public List<Horse> finishers = new List<Horse>();
    public int totalHorsesInRace = 4;

    public void RecordFinisher(Horse horse)
    {
        if (!finishers.Contains(horse))
        {
            finishers.Add(horse);
            Debug.Log($"{horse.stats.horseName} finished in position {finishers.Count}");

            // If all horses have finished, calculate payouts
            if (finishers.Count == totalHorsesInRace)
            {
                DeterminePayouts();
            }
        }
    }

    void DeterminePayouts()
    {
        // Example IDs for the top 3
        int firstPlaceID = finishers[0].stats.horseID;
        int secondPlaceID = finishers[1].stats.horseID;
        int thirdPlaceID = finishers[2].stats.horseID;

        // Pass these to your Betting System
    }
}
