using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public int playerBetHorseID; // Set this when the player places a bet
    public float betAmount;
    private bool raceOver = false;

    // Triggered when a horse hits the finish line
    private void OnTriggerEnter(Collider other)
    {
        if (raceOver) return; // Only care about the first winner

        // Get the Horse script from the object that hit the finish line
        Horse horse = other.GetComponent<Horse>();

        if (horse != null)
        {
            raceOver = true;
            CheckWinner(horse.horseID);
        }
    }

    void CheckWinner(int winningID)
    {
        Debug.Log("Horse " + winningID + " won the race!");

        if (winningID == playerBetHorseID)
        {
            float payout = betAmount * 2; // Simple 2x payout logic
            Debug.Log("You Win! Payout: $" + payout);
            // Add money to player's wallet here
        }
        else
        {
            Debug.Log("You Lose!");
        }
    }
}
