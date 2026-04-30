using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public BettingManager bettingManager; // Drag BettingManager here
    private bool raceOver = false;

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Something entered finish line: " + other.name);

            if (!raceOver && other.CompareTag("Horse"))
            {
                raceOver = true;

                string winner = other.gameObject.name;
                winText.gameObject.SetActive(true);

                if (winner == bettingManager.pickedHorseName)
                {
                    winText.text = winner + " Won! You won $" + (bettingManager.currentBetAmount * 2);
                    bettingManager.AddWinnings(2f);
                }
                else
                {
                    winText.text = winner + " Won. You lost your bet.";
                }

                FindObjectOfType<RaceManager>().StopAllHorses();

                Debug.Log("Horse crossed finish line!");
            }
    }
}
