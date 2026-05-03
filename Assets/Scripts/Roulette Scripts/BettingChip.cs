using System.Collections.Generic;
using UnityEngine;

public class BettingChip : MonoBehaviour
{
    public float detectionRadius = 0.15f;
    public LayerMask rouletteButtonLayer;

    public RouletteBetType placedBetType = RouletteBetType.Invalid;
    public List<string> placedNumbers = new List<string>();
    public int betAmount = 10;


    public List<RouletteButton> GetOverlappingButtons()
    {
        List<RouletteButton> found = new List<RouletteButton>();

        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, rouletteButtonLayer);

        foreach (Collider hit in hits)
        {
            RouletteButton rb = hit.GetComponent<RouletteButton>();
            if (rb != null && !found.Contains(rb))
            {
                found.Add(rb);
            }
        }

        return found;
    }

    public List<string> GetBetNumbers()
    {
        List<string> numbers = new List<string>();

        foreach (RouletteButton rb in GetOverlappingButtons())
        {
            if (!string.IsNullOrEmpty(rb.betNumber) && !numbers.Contains(rb.betNumber))
            {
                numbers.Add(rb.betNumber);
            }
        }

        return numbers;
    }

    public RouletteBetType GetBetType()
    {
        List<RouletteButton> buttons = GetOverlappingButtons();

        // First check for special outside bets like Red/Black/Even/Odd
        foreach (RouletteButton rb in buttons)
        {
            if (rb.isSpecialBet)
            {
                return rb.specialBetType;
            }
        }

        // Otherwise determine inside bet from number overlap count
        int count = GetBetNumbers().Count;

        switch (count)
        {
            case 1: return RouletteBetType.Straight;
            case 2: return RouletteBetType.Split;
            case 3: return RouletteBetType.Street;
            case 4: return RouletteBetType.Corner;
            default: return RouletteBetType.Invalid;
        }
    }

    public void ResolvePlacement()
    {
        placedBetType = GetBetType();
        placedNumbers = GetBetNumbers();

        if (placedBetType == RouletteBetType.Invalid)
        {
            Debug.Log("Invalid bet placement.");
            Destroy(gameObject);
            return;
        }

        DebugBet();
        RouletteGameMaster.Instance.RegisterBet(this);
    }

    public void DebugBet()
    {

        Debug.Log("Type: " + placedBetType);

        if (placedNumbers.Count > 0)
            Debug.Log("Numbers: " + string.Join(", ", placedNumbers));
        else
            Debug.Log("Numbers: None");


    }

    public void RemoveBet()
    {
        RouletteGameMaster.Instance.RemoveBet(this);
        Destroy(gameObject);
    }
}