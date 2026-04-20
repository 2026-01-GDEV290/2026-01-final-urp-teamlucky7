using UnityEngine;
using System.Collections;

public class HorseRaceManager : MonoBehaviour
{
    public GameObject[] horses;
    public Transform finishLine;
    private bool isRacing = false;

    // Start race via button
    public void StartRace()
    {
        StartCoroutine(RaceRoutine());
    }

    IEnumerator RaceRoutine()
    {
        isRacing = true;
        while (isRacing)
        {
            for (int i = 0; i < horses.Length; i++)
            {
                // Random speed variance
                float speed = Random.Range(1f, 5f);
                horses[i].transform.Translate(Vector3.forward * speed * Time.deltaTime);

                if (horses[i].transform.position.z >= finishLine.position.z)
                {
                    isRacing = false;
                    Debug.Log("Winner: Horse " + i);
                    // Call BettingManager.OnRaceEnd here
                    break;
                }
            }
            yield return null;
        }
    }
    internal static void hasFinished(HorseData horse)
    {
        throw new System.NotImplementedException();
    }
}
