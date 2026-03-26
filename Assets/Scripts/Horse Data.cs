using UnityEngine;

public class HorseData : MonoBehaviour
{
    public string horseName;
    public int lastCheckpoint = 0;
    public float distanceToNextCheckpoint = 0f;
    public bool finished = false;
    public float finishTime = 0f;

    // Call this whenever a horse passes a checkpoint
    public void UpdateProgress(int checkpointIndex, float distance)
    {
        lastCheckpoint = checkpointIndex;
        distanceToNextCheckpoint = distance;
    }
}

