using UnityEngine;
using System.Collections.Generic;

public class FinishLine : MonoBehaviour
{
    public HorseRaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HorseData>())
        {
            HorseData horse = other.GetComponent<HorseData>();
            if (!horse.finished)
            {
                horse.finished = true;
                horse.finishTime = Time.time;
                HorseRaceManager.hasFinished(horse);
            }
        }
    }
}