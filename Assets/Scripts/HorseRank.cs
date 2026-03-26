using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HorseRank : MonoBehaviour
{
    public List<string> raceResults = new List<string>();
    private bool raceFinished = false;
    internal bool hasFinished;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object passing through is a horse and race is active
        if (other.CompareTag("Horse") && !raceFinished)
        {
            string horseName = other.gameObject.name;

            // Ensure the same horse isn't added twice
            if (!raceResults.Contains(horseName))
            {
                raceResults.Add(horseName);
                Debug.Log(horseName + " finished in position: " + raceResults.Count);
            }

            // If all horses have finished (assuming 3 horses for this example)
            if (raceResults.Count >= 3)
            {
                FinishRace();
            }
        }
    }

    void FinishRace()
    {
        raceFinished = true;
        Debug.Log("Race Over!");
        Debug.Log("1st Place: " + raceResults[0]);
        Debug.Log("2nd Place: " + raceResults[1]);
        Debug.Log("3rd Place: " + raceResults[2]);

        // --- ADD BETTING LOGIC HERE ---
        // e.g., Check if finishOrder[0] matches player bet
    }
}