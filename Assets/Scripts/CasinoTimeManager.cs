using UnityEngine;

public class CasinoTimeManager : MonoBehaviour
{
    public static CasinoTimeManager Instance;

    [Header("Casino Hours")]
    [SerializeField] private int openHour = 12;
    [SerializeField] private int closeHour = 24;

    [Header("Current Time")]
    [SerializeField] private int currentDay = 1;
    [SerializeField] private int currentHour;
    [SerializeField] private int currentMinute;

    public int CurrentDay => currentDay;

    private int OpenMinutes => openHour * 60;
    private int CloseMinutes => closeHour * 60;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        currentHour = openHour;
        currentMinute = 0;
    }

    public int GetCurrentTimeInMinutes()
    {
        return currentHour * 60 + currentMinute;
    }

    public int GetRemainingMinutesToday()
    {
        return CloseMinutes - GetCurrentTimeInMinutes();
    }

    public bool CanSpendTime(int minutesToSpend)
    {
        return GetRemainingMinutesToday() >= minutesToSpend;
    }

    public bool SpendTime(int minutesToSpend)
    {
        if (!CanSpendTime(minutesToSpend))
            return false;

        int totalMinutes = GetCurrentTimeInMinutes() + minutesToSpend;

        currentHour = totalMinutes / 60;
        currentMinute = totalMinutes % 60;

        RefreshPlayerUI();

        return true;
    }


    public string GetFormattedTime()
    {
        int displayHour = currentHour;
        string suffix = "AM";

        if (displayHour >= 12)
            suffix = "PM";

        if (displayHour == 0)
            displayHour = 12;
        else if (displayHour > 12)
            displayHour -= 12;

        return displayHour + ":" + currentMinute.ToString("00") + " " + suffix;
    }

    public string GetFormattedRemainingTime()
    {
        int remaining = GetRemainingMinutesToday();
        int hours = remaining / 60;
        int minutes = remaining % 60;

        return hours + "h " + minutes.ToString("00") + "m";
    }

    private void RefreshPlayerUI()
    {
        PlayerinfoDisplay display = FindFirstObjectByType<PlayerinfoDisplay>();

        if (display != null)
        {
            display.RefreshDisplay();
        }
    }
}