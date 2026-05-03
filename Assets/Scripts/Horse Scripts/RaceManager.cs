using UnityEngine;
using TMPro; // Add this for UI reference

public class RaceManager : MonoBehaviour
{
    public HorseMovement[] horses;
    public BettingManager bettingManager;
    public Vector3[] startPositions; // Array to save starting spots
    public GameObject restartButton; // Reference to your restart button
    public TextMeshProUGUI winText;  // Reference to the winner text

    void Start()
    {
        // Save the initial positions of all horses at the start of the game
        startPositions = new Vector3[horses.Length];
        for (int i = 0; i < horses.Length; i++)
        {
            startPositions[i] = horses[i].transform.position;
        }
    }

    public void OnRaceButtonPressed()
    {
        StopAllHorses(); // Safety check
        if (bettingManager.PlaceBet())
        {
            foreach (HorseMovement horse in horses)
            {
                horse.StartRace();
            }
        }
        else
        {
            Debug.Log("You need a valid bet to race!");
        }
        // Hide UI when a new race starts
        restartButton.SetActive(false);
        winText.gameObject.SetActive(false);
    }

    public void StopAllHorses()
    {
        foreach (HorseMovement horse in horses)
        {
            horse.StopRace();
        }

        restartButton.SetActive(true);

    }

    public void ResetRace()
    {
        // Move horses back to their saved start positions
        for (int i = 0; i < horses.Length; i++)
        {
            horses[i].transform.position = startPositions[i];
            horses[i].StopRace();
        }

        // Clear UI
        winText.gameObject.SetActive(false);
        restartButton.SetActive(false);
    }
}
