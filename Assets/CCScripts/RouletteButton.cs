using UnityEngine;

public class RouletteButton : MonoBehaviour
{
    public string betNumber; // "1", "17", "0", "00"
    public bool isSpecialBet;
    public RouletteBetType specialBetType = RouletteBetType.Invalid;
}