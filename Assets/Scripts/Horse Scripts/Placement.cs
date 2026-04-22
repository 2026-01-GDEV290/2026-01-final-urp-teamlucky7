using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Placement : MonoBehaviour
{
    public List<Horse> allHorses; // Assign all competing horses here

    // Lists to track progress
    private List<Horse> liveRankings = new List<Horse>();
    private List<Horse> finishedHorses = new List<Horse>();

    private bool raceActive = false;

    void Update()
    {
        if (raceActive)
        {
            UpdateLiveRankings();
        }
    }

    // 1. Calculates rankings WHILE racing
    void UpdateLiveRankings()
    {
        // Sort horses by their Z-position (distance traveled)
        // Only sort horses that haven't finished yet
        var racing = allHorses.Except(finishedHorses)
                              .OrderByDescending(h => h.transform.position.z)
                              .ToList();

        // The full list is Finished Horses (in order) + Racing Horses (by distance)
        liveRankings = new List<Horse>(finishedHorses);
        liveRankings.AddRange(racing);

        // Optional: Assign rank value to the horse scripts for UI use
        for (int i = 0; i < liveRankings.Count; i++)
        {
            // liveRankings[0] is 1st place
            int rank = i + 1;
            // Debug.Log($"{liveRankings[i].horseName} is in P{rank}");
        }
    }

    // 2. Called by the FinishLine script when a horse crosses
    public void RegisterFinish(Horse horse)
    {
        if (!finishedHorses.Contains(horse))
        {
            finishedHorses.Add(horse);
            Debug.Log($"{horse.horseName} FINISHED in position: {finishedHorses.Count}");

            if (finishedHorses.Count == allHorses.Count)
            {
                EndRace();
            }
        }
    }

    public void StartRace() => raceActive = true;

    void EndRace()
    {
        raceActive = false;
        Debug.Log("Race Over! Winner: " + finishedHorses[0].horseName);
    }

    // Helper to check if a specific horse won
    public bool DidHorseWin(string name)
    {
        return finishedHorses.Count > 0 && finishedHorses[0].horseName == name;
    }
}
