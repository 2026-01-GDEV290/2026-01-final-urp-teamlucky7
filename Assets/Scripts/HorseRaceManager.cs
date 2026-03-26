using UnityEngine;
using System.Collections.Generic;

public class HorseRaceManager : MonoBehaviour
{
    public float baseSpeed = 10f;
    public float speedVariation = 2f;
    private float currentSpeed;

    // Pathfinding or Waypoint System
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    internal int totalLaps;

    void Update()
    {
        // 1. Calculate fluctuating speed
        currentSpeed = baseSpeed + Random.Range(-speedVariation, speedVariation);

        // 2. Move towards next waypoint
        if (waypoints.Length > 0)
        {
            Transform target = waypoints[currentWaypointIndex];
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * currentSpeed * Time.deltaTime;


            // Check if waypoint reached
            if (Vector3.Distance(transform.position, target.position) < 1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }

        // 3. Update Animator (if applicable)
        // GetComponent<Animator>().SetFloat("Speed", currentSpeed);
    }

    void EndRace(GameObject winner)
    {
        Debug.Log(winner.name + " won the race!");
    }

    internal void OnHorseFinish(Placement horse)
    {
        throw new System.NotImplementedException();
    }

    internal static void hasFinished(HorseData horse)
    {
        throw new System.NotImplementedException();
    }
}