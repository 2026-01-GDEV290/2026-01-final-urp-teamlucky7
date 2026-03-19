using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Placement : MonoBehaviour
{
    public List<HorseData> horses;
    public Transform finishLine;
    private bool isRacing = false;

    public void StartRace()
    {
        if (!isRacing) StartCoroutine(RaceSimulation());
    }

    IEnumerator RaceSimulation()
    {
        isRacing = true;
        Debug.Log("Race Started!");

        while (!CheckForWinner())
        {
            foreach (var horse in horses)
            {
                // Simulate speed with random variation
                float speed = horse.baseSpeed * Random.Range(0.8f, 1.2f);
                horse.currentPosition += speed * Time.deltaTime;
            }
            yield return null; // Wait for next frame
        }

        isRacing = false;
        Debug.Log("Race Finished!");
    }

    bool CheckForWinner()
    {
        foreach (var horse in horses)
        {
            if (horse.currentPosition >= finishLine.position.z)
            {
                Debug.Log(horse.horseName + " wins!");
                return true;
            }
        }
        return false;
    }
}