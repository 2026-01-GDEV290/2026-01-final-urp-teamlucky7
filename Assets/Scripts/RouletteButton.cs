using UnityEngine;

public class RouletteButton : MonoBehaviour
{
    public string betNumber; // "1", "17", "0", "00"

    void OnMouseDown()
    {
        RoughRouletteMaster.Instance.PlaceBet(betNumber);
    }
}