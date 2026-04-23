using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Placement : MonoBehaviour
{
    public HorseMovement[] horses; // Assign all horse objects here in Inspector

    public void StartAllHorses()
    {
        foreach (HorseMovement horse in horses)
        {
            horse.StartRace();
        }
    }
}