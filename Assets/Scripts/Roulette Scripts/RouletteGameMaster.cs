using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RouletteGameMaster : MonoBehaviour
{
    public static RouletteGameMaster Instance;

    public AudioSource audioSource;
    public AudioClip chipSound;
    public AudioClip winSound;
    public AudioClip loseSound;

    private readonly List<BettingChip> activeBets = new List<BettingChip>();

    public TMP_Text resultText;
    public TMP_Text moneyText;
    public TMP_Text winText;

    private bool bettingLocked = false;

    private HashSet<int> redNumbers = new HashSet<int>
    {
        1,3,5,7,9,12,14,16,18,
        19,21,23,25,27,30,32,34,36
    };

    private HashSet<int> evenNumbers = new HashSet<int>
    {
        2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36
    };

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateMoneyText();
        RefreshSharedPlayerUI();
    }

    public bool HasAnyBetsPlaced()
    {
        return activeBets.Count > 0;
    }

    public void LockBetting()
    {
        bettingLocked = true;
    }

    public void UnlockBetting()
    {
        bettingLocked = false;
    }

    public bool IsBettingLocked()
    {
        return bettingLocked;
    }

    public void RegisterBet(BettingChip chip)
    {
        if (chip == null) return;

        if (bettingLocked)
        {
            Debug.Log("Betting is locked.");
            Destroy(chip.gameObject);
            return;
        }

        if (Playerinfo.Instance == null)
        {
            Debug.LogWarning("Playerinfo instance missing.");
            Destroy(chip.gameObject);
            return;
        }

        if (!Playerinfo.Instance.RemoveMoney(chip.betAmount))
        {
            Debug.Log("Not enough money to place bet.");
            Destroy(chip.gameObject);
            return;
        }

        UpdateMoneyText();
        RefreshSharedPlayerUI();

        if (!activeBets.Contains(chip))
        {
            activeBets.Add(chip);
            audioSource.PlayOneShot(chipSound);
        }

        Debug.Log("Registered Bet:");
        Debug.Log("Type = " + chip.placedBetType);
        Debug.Log("Numbers = " + string.Join(", ", chip.placedNumbers));
        Debug.Log("Amount = $" + chip.betAmount);
    }

    public void RemoveBet(BettingChip chip)
    {
        if (chip == null) return;

        if (bettingLocked)
        {
            Debug.Log("Betting is locked.");
            return;
        }

        if (activeBets.Remove(chip))
        {
            if (Playerinfo.Instance != null)
            {
                Playerinfo.Instance.AddMoney(chip.betAmount);
            }

            UpdateMoneyText();
            RefreshSharedPlayerUI();

            Debug.Log("Removed Bet:");
            Debug.Log("Type = " + chip.placedBetType);
            Debug.Log("Numbers = " + string.Join(", ", chip.placedNumbers));
        }
    }

    public void ResolveSpinResult(string result)
    {
        if (activeBets.Count == 0)
        {
            Debug.Log("No bets placed.");
            return;
        }

        DisplayResult(result);

        int totalWon = 0;

        foreach (BettingChip chip in activeBets)
        {
            if (chip == null) continue;

            bool win = DidBetWin(chip, result);
            int payout = 0;

            if (win)
            {
                payout = GetPayout(chip);

                if (Playerinfo.Instance != null)
                {
                    Playerinfo.Instance.AddMoney(payout);
                }

                totalWon += payout;
            }

            Debug.Log(
                $"Bet Type: {chip.placedBetType} | Numbers: [{string.Join(", ", chip.placedNumbers)}] | Bet: ${chip.betAmount} | " +
                (win ? $"WIN! Payout = ${payout}" : "LOSE!")
            );
        }

        UpdateMoneyText();
        RefreshSharedPlayerUI();

        if (winText != null)
        {
            if (totalWon > 0)
            {
                winText.text = "YOU WIN!";
                winText.color = Color.green;
                audioSource.PlayOneShot(winSound);
            }
            else
            {
                winText.text = "YOU LOSE";
                winText.color = Color.red;
                audioSource.PlayOneShot(loseSound);
            }
        }

        Debug.Log("Roulette landed on " + result);
        Debug.Log("Total Won This Spin: $" + totalWon);

        ClearAllBets();
    }

    private bool DidBetWin(BettingChip chip, string result)
    {
        switch (chip.placedBetType)
        {
            case RouletteBetType.Red:
                return IsRed(result);

            case RouletteBetType.Black:
                return IsBlack(result);

            case RouletteBetType.Even:
                return IsEven(result);

            case RouletteBetType.Odd:
                return IsOdd(result);

            case RouletteBetType.Straight:
            case RouletteBetType.Split:
            case RouletteBetType.Street:
            case RouletteBetType.Corner:
                return chip.placedNumbers.Contains(result);

            default:
                return false;
        }
    }

    private int GetPayout(BettingChip chip)
    {
        switch (chip.placedBetType)
        {
            case RouletteBetType.Straight:
                return chip.betAmount * 36;
            case RouletteBetType.Split:
                return chip.betAmount * 18;
            case RouletteBetType.Street:
                return chip.betAmount * 12;
            case RouletteBetType.Corner:
                return chip.betAmount * 9;
            case RouletteBetType.Red:
            case RouletteBetType.Black:
            case RouletteBetType.Even:
            case RouletteBetType.Odd:
                return chip.betAmount * 2;
            default:
                return 0;
        }
    }

    private void DisplayResult(string result)
    {
        if (resultText == null) return;

        resultText.text = result;

        if (result == "0" || result == "00")
            resultText.color = Color.green;
        else if (IsRed(result))
            resultText.color = Color.red;
        else
            resultText.color = Color.black;
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            int balance = 0;

            if (Playerinfo.Instance != null)
                balance = Playerinfo.Instance.currentBalance;

            moneyText.text = "$" + balance;
        }
    }

    private void RefreshSharedPlayerUI()
    {
        PlayerinfoDisplay display = FindFirstObjectByType<PlayerinfoDisplay>();

        if (display != null)
        {
            display.RefreshDisplay();
        }
    }

    private void ClearAllBets()
    {
        foreach (BettingChip chip in activeBets)
        {
            if (chip != null)
                Destroy(chip.gameObject);
        }

        activeBets.Clear();
    }

    private bool IsRed(string number)
    {
        if (number == "0" || number == "00") return false;
        return redNumbers.Contains(int.Parse(number));
    }

    private bool IsBlack(string number)
    {
        if (number == "0" || number == "00") return false;
        return !redNumbers.Contains(int.Parse(number));
    }

    private bool IsEven(string number)
    {
        if (number == "0" || number == "00") return false;
        return evenNumbers.Contains(int.Parse(number));
    }

    private bool IsOdd(string number)
    {
        if (number == "0" || number == "00") return false;
        return !evenNumbers.Contains(int.Parse(number));
    }
}