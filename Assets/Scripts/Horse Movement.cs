using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    [Range(0, 100)]
    public float chanceOfSuccess = 50f; // 50% chance

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckOdds(chanceOfSuccess))
            {
                Debug.Log("Success!");
            }
            else
            {
                Debug.Log("Failure.");
            }
        }
    }

    // Returns true if the event occurs
    public bool CheckOdds(float percentage)
    {
        // Random.value returns a float between 0.0 and 1.0
        return Random.value < (percentage / 100f);
    }
}