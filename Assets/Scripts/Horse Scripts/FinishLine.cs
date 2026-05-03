using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winSound;
    public AudioClip loseSound;
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
                    audioSource.PlayOneShot(winSound);
                }
                else
                {
                    
                    winText.text = winner + " Won. You lost your bet.";
                    audioSource.PlayOneShot(loseSound);

            }

                FindObjectOfType<RaceManager>().StopAllHorses();

                Debug.Log("Horse crossed finish line!");
            }
    }
}
