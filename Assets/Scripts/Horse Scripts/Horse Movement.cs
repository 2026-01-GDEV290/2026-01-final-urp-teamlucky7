using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    public float speed = 10f;

    void Update()
    {
        if (currentWaypoint >= waypoints.Length) return;

        // Move towards current waypoint
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        // Switch to next waypoint when close
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 2f)
        {
            currentWaypoint++;
        }
    }
}