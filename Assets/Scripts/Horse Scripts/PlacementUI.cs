using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlacementUIManager : MonoBehaviour
{
    public List<Horse> horses; // Drag your horses here
    public GameObject entryPrefab; // Drag your LeaderboardEntry prefab here
    public Transform contentPanel; // The object with the Vertical Layout Group

    private List<LeaderBoard> uiEntries = new List<LeaderBoard>();

    void Start()
    {
        // Create a UI row for every horse in the race
        foreach (var horse in horses)
        {
            GameObject go = Instantiate(entryPrefab, contentPanel);
            uiEntries.Add(go.GetComponent<LeaderBoard>());
        }
    }

    void Update()
    {
        // 1. Sort horses by distance (Z-axis)
        var rankedHorses = horses.OrderByDescending(h => h.transform.position.z).ToList();

        // 2. Update the UI rows to match the current rank
        for (int i = 0; i < rankedHorses.Count; i++)
        {
            uiEntries[i].UpdateEntry(i + 1, rankedHorses[i].data);

            // Optional: Change color if it's the horse the player bet on
            // uiEntries[i].horseNameText.color = rankedHorses[i].isPlayerBet ? Color.yellow : Color.white;
        }
    }
}
