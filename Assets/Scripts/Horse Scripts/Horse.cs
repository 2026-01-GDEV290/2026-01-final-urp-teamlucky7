using UnityEngine;

public class Horse : MonoBehaviour
{
    public HorseData stats; // Drag stats here or fill in Inspector
    private bool isRacing = false;
    internal object horseName;
    internal object data;
    internal int horseID;

    void Update()
    {
        if (isRacing)
        {
            // Move forward based on speed stat
            float randomBoost = Random.Range(-0.5f, 0.5f);
            float movement = (stats.baseSpeed + randomBoost) * Time.deltaTime;
            transform.Translate(Vector3.forward * movement);
        }
    }

    public void StartRace() { isRacing = true; }
    public void StopRace() { isRacing = false; }
}
