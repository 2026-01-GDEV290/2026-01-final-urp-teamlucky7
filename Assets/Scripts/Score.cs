using UnityEngine;
using UnityEngine.UI; // Needed for UI updates

public class Score : MonoBehaviour
{
    public static Score Instance; // Singleton instance

    public int currentMoney;
    public Text moneyText; // Drag your UI Text here

    private void Awake()
    {
        // Setup Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Load saved money on start
        currentMoney = PlayerPrefs.GetInt("SavedMoney", 0);
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        SaveMoney();
        UpdateUI();
    }

    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            SaveMoney();
            UpdateUI();
            return true; // Purchase successful
        }
        return false; // Not enough money
    }

    void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = "Money: " + currentMoney.ToString();
        }
    }

    void SaveMoney()
    {
        PlayerPrefs.SetInt("SavedMoney", currentMoney);
        PlayerPrefs.Save();
    }
}