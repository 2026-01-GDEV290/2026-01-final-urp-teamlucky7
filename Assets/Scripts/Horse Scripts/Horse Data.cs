using UnityEngine;

// This class holds the "stats" for each horse
[System.Serializable]
public class HorseData : MonoBehaviour
{
    public string horseName;
    public int horseID;
    public float baseSpeed;    // Average speed
    public float stamina;     // Used to calculate late-race fatigue
    public float winOdds;     // Multiplier for payouts (e.g., 3.5 for $3.50 return on $1)
}
