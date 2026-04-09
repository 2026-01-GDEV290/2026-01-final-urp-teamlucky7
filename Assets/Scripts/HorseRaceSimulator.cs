using UnityEngine;
using System.Collections;

public class HorseRaceSimulator : MonoBehaviour
{
    public Transform[] horses; // Assign horse transforms in Inspector
    public float finishLine = 100f;
    private bool raceActive = false;

    public void StartRace()
    {
        StartCoroutine(RaceRoutine());
    }

    IEnumerator RaceRoutine()
    {
        raceActive = true;
        while (raceActive)
        {
            for (int i = 0; i < horses.Length; i++)
            {
                // Move horses forward based on random speed
                horses[i].Translate(Vector3.forward * Random.Range(0.5f, 2f));

                if (horses[i].position.z >= finishLine)
                {
                    raceActive = false;
                    Debug.Log($"Horse {i + 1} Won!");
                    FindObjectOfType<BettingManager>().OnRaceFinished(i + 1);
                    break;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
