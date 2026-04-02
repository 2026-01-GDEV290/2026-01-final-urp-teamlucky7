using UnityEngine;
using TMPro; 

public class TimeIncrementor : MonoBehaviour
{
    public int truehour = 0;
    public int hour = 8;
    public int minute = 0;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI trueHourText;
    void Start()
    {
        UpdateTimeDisplay();
    }

    public void IncrementTime()
    {
        minute += 30;
        truehour++;

        if (minute >= 60)
        {
            minute = 0;
            hour++;
            
        }

        if (hour > 12)
        {
            hour = 1;
        }

        UpdateTimeDisplay();
    }

    void UpdateTimeDisplay()
    {
        string period = "AM";

        if (truehour >= 4)
            period = "PM";

        int displayHour = hour;

        if (displayHour > 12)
            displayHour -= 12;

        timeText.text = displayHour + ":" + minute.ToString("00") + " " + period;
        trueHourText.text = truehour + "/28";
        if (truehour >= 28)
            timeText.text = "DAY OVER";

    }
}
