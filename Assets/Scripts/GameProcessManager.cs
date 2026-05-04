using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameProcessManager : MonoBehaviour
{
    public static GameProcessManager Instance;

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
        }
    }

    public void EvaluateGameState()
    {
        if (Playerinfo.Instance == null || CasinoTimeManager.Instance == null)
            return;

        if (Playerinfo.Instance.currentBalance <= 0)
        {
            HandlePlayerBroke();
            return;
        }

        if (CasinoTimeManager.Instance.GetRemainingMinutesToday() <= 0)
        {
            HandleDayEnded();
            return;
        }
    }

    public bool TrySpendTime(int amount)
    {
        if (CasinoTimeManager.Instance == null)
            return false;

        if (!CasinoTimeManager.Instance.CanSpendTime(amount))
        {
            HandleDayEnded();
            return false;
        }

        CasinoTimeManager.Instance.SpendTime(amount);
        return true;
    }

    private void HandleDayEnded()
    {
        Debug.Log("Day ended.");
        SceneManager.LoadScene(8);

    }

    private void HandlePlayerBroke()
    {
        Debug.Log("Player is out of money.");
        SceneManager.LoadScene(0);


    }
}