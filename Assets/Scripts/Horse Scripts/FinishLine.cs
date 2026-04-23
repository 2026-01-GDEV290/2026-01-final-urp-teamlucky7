using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public BettingManager bettingManager; // Drag BettingManager here
    private bool raceOver = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!raceOver && other.CompareTag("Horse"))
        {
            raceOver = true;
            string winner = other.gameObject.name;
            winText.gameObject.SetActive(true);

            // Check if player picked this horse
            if (winner == bettingManager.pickedHorseName)
            {
                winText.text = winner + " Won! You won $" + (bettingManager.currentBetAmount * 2);
                bettingManager.AddWinnings(2f); // 2x Payout for a win
            }
            else
            {
                winText.text = winner + " Won. You lost your bet.";
            }

            FindObjectOfType<RaceManager>().StopAllHorses();
        }
    }
}
