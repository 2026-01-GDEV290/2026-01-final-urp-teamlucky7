using UnityEngine;
using System.Collections.Generic;

public class RoughRouletteMaster : MonoBehaviour
{
    public static RoughRouletteMaster Instance;

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

    public void PlaceBet(string bet)
    {
        string result = GetRandomResult();

        Debug.Log($"You bet on {bet}");
        Debug.Log($"Roulette landed on {result}");

        bool win = false;

        //  NUMBER BET
        if (bet == result)
        {
            win = true;
        }
        //  RED BET
        else if (bet == "RED")
        {
            if (IsRed(result))
                win = true;
        }
        //  BLACK BET
        else if (bet == "BLACK")
        {
            if (IsBlack(result))
                win = true;
        }
        //  EVEN BET
        else if (bet == "EVEN")
        {
            if (IsEven(result))
                win = true;
        }
        //  ODD BET
        else if (bet == "ODD")
        {
            if (IsOdd(result))
                win = true;
        }
        if (win)
            Debug.Log("WIN!");
        else
            Debug.Log("LOSE!");
    }

    string GetRandomResult()
    {
        int roll = Random.Range(0, 38);
        return roll == 37 ? "00" : roll.ToString();
    }

    bool IsRed(string number)
    {
        if (number == "0" || number == "00") return false;

        int num = int.Parse(number);
        return redNumbers.Contains(num);
    }

    bool IsBlack(string number)
    {
        if (number == "0" || number == "00") return false;

        int num = int.Parse(number);
        return !redNumbers.Contains(num);
    }
    
    bool IsEven(string number)
    {
        if (number == "0" || number == "00") return false;

        int num = int.Parse(number);
        return evenNumbers.Contains(num);
    }
    
    bool IsOdd(string number)
    {
        if (number == "0" || number == "00") return false;

        int num = int.Parse(number);
        return !evenNumbers.Contains(num);
    }
}