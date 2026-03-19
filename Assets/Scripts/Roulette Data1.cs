using System.Collections.Generic;
using UnityEngine;

public enum RouletteColor
{
    Red,
    Black,
    Green
}

[System.Serializable]
public class RouletteNumber
{
    public string number; // "0", "00", "1"..."36"
    public RouletteColor color;

    public RouletteNumber(string number, RouletteColor color)
    {
        this.number = number;
        this.color = color;
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

        // Add 0 and 00
        numbers.Add("0", new RouletteNumber("0", RouletteColor.Green));
        numbers.Add("00", new RouletteNumber("00", RouletteColor.Green));

        // Add 1–36
        for (int i = 1; i <= 36; i++)
        {
            RouletteColor color = redNumbers.Contains(i) ? RouletteColor.Red : RouletteColor.Black;
            numbers.Add(i.ToString(), new RouletteNumber(i.ToString(), color));
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
}