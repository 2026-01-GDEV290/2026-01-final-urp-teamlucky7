using UnityEngine;



public class RouletteRoundBridge : MonoBehaviour
{
    [SerializeField] private RouletteGameMaster bettingMaster;
    [SerializeField] private WheelManager wheelManager;
    [SerializeField] private RouletteBallController ballController;
    [SerializeField] private GameObject wheelDisplayPlane;
    [SerializeField] private int rouletteTimeCost = 30;



    private bool roundInProgress = false;

    private void Start()
    {
        if (wheelDisplayPlane != null)
            wheelDisplayPlane.SetActive(false);

        if (bettingMaster == null)
            bettingMaster = FindFirstObjectByType<RouletteGameMaster>();

        if (wheelManager == null)
            wheelManager = FindFirstObjectByType<WheelManager>();

        if (ballController == null)
            ballController = FindFirstObjectByType<RouletteBallController>();

        if (ballController != null)
        {
            ballController.OnBallLanded += HandleBallLanded;
        }
    }

    private void OnDestroy()
    {
        if (ballController != null)
        {
            ballController.OnBallLanded -= HandleBallLanded;
        }
    }

    public void ConfirmBetsAndSpin()
    {
        if (roundInProgress)
            return;

        if (!bettingMaster.HasAnyBetsPlaced())
        {
            Debug.Log("No bets placed.");
            return;
        }

    
        if (!GameProcessManager.Instance.TrySpendTime(rouletteTimeCost))
        {
            return;
        }

        // Spend time AFTER check
        CasinoTimeManager.Instance.SpendTime(rouletteTimeCost);

        roundInProgress = true;
        bettingMaster.LockBetting();
        if (wheelDisplayPlane != null)
        wheelDisplayPlane.SetActive(true);
        wheelManager.StartSpin();
    }

    private void HandleBallLanded(int landedNumber)
    {
        string result = ConvertWheelNumberToResultString(landedNumber);

        bettingMaster.ResolveSpinResult(result);
        bettingMaster.UnlockBetting();

        roundInProgress = false;
        if (wheelDisplayPlane != null)
            wheelDisplayPlane.SetActive(false);
    }

    private string ConvertWheelNumberToResultString(int landedNumber)
    {
        if (landedNumber == 37)
            return "00";

        return landedNumber.ToString();
    }
}