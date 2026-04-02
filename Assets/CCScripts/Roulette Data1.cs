using System.Collections.Generic;
using UnityEngine;

public enum RouletteColor
{
    Red,
    Black,
    Green
}

public enum RouletteEven
{
    Even,
    Odd,
    Null
}

public enum RouletteDozen
{
    FirstDozen,
    SecondDozen,
    ThirdDozen,
    Null
}

[System.Serializable]
public class RouletteNumber
{
    public string number; // "0", "00", "1"..."36"
    public RouletteColor color;
    public RouletteEven even;
    public RouletteDozen dozen;

    public RouletteNumber(string number, RouletteColor color, RouletteEven even) //RouletteDozen dozen)
    {
        this.number = number;
        this.color = color;
        this.even = even;
        this.dozen = dozen;
    }
}

public class RouletteData : MonoBehaviour
{
    public static RouletteData Instance;

    public Dictionary<string, RouletteNumber> numbers = new Dictionary<string, RouletteNumber>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        InitializeNumbers();
    }

    void InitializeNumbers()
    {
        // Red numbers
        HashSet<int> redNumbers = new HashSet<int>
        {
            1,3,5,7,9,12,14,16,18,
            19,21,23,25,27,30,32,34,36
        };

        HashSet<int> evenNumbers = new HashSet<int>
        {
            2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36
        };

        HashSet<int> firstDozenNumbers = new HashSet<int>
        {
            1,2,3,4,5,6,7,8,9,10,11,12
        };
        HashSet<int> secondDozenNumbers = new HashSet<int>
        {
            13,14,15,16,17,18,19,20,21,22,23,24
        };
        HashSet<int> thirdDozenNumbers = new HashSet<int>
        {
            25,26,27,28,29,30,31,32,33,34,35,36
        };

        // Add 0 and 00
        numbers.Add("0", new RouletteNumber("0", RouletteColor.Green, RouletteEven.Null));//, RouletteDozen.Null));
        numbers.Add("00", new RouletteNumber("00", RouletteColor.Green,RouletteEven.Null));//, RouletteDozen.Null));

        // Add 1–36
        for (int i = 1; i <= 36; i++)
        {
            RouletteColor color = redNumbers.Contains(i) ? RouletteColor.Red : RouletteColor.Black;
            RouletteEven even = evenNumbers.Contains(i) ? RouletteEven.Even : RouletteEven.Odd;
            //RouletteDozen FirstDozen = firstDozenNumbers.Contains(i) ? RouletteDozen.FirstDozen;
            //RouletteDozen SecondDozen = SecondDozenNumbers.Contains(i) ? RouletteDozen.SecondDozen;
            //RouletteDozen ThirdDozen = ThirdDozenNumbers.Contains(i) ? RouletteDozen.ThirdDozen;

            numbers.Add(i.ToString(), new RouletteNumber(i.ToString(), color, even));
        }
    }

    // Helper method to get color
    public RouletteColor GetColor(string number)
    {
        if (numbers.ContainsKey(number))
            return numbers[number].color;

        Debug.LogWarning("Number not found: " + number);
        return RouletteColor.Green;
    }

    // Helper method to get even
    public RouletteEven GetEven(string number)
    {
        if (numbers.ContainsKey(number))
            return numbers[number].even;

        Debug.LogWarning("Number not found: " + number);
        return RouletteEven.Null;
    }

    // Helper method to get dozen
   // public RouletteDozen GetDozen(string number)
   // {
   //     if (numbers.ContainsKey(number))
   //         return numbers[number].dozen;
//
   //     Debug.LogWarning("Number not found: " + number);
   //     return RouletteDozen.Null;
    //}
}