using System.Collections.Generic;
using UnityEngine;

public enum BetKind
{
    Straight,
    Split,
    Corner,
    Street,
    Red,
    Black,
    Even,
    Odd
}

public class BetZone : MonoBehaviour
{
    public BetKind betKind;
    public List<string> coveredNumbers = new List<string>();
}