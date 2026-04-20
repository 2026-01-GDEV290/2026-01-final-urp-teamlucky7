using UnityEngine;



public class RouletteRoundBridge : MonoBehaviour
{
    [SerializeField] private RouletteGameMaster bettingMaster;
    [SerializeField] private WheelManager wheelManager;
    [SerializeField] private RouletteBallController ballController;
    [SerializeField] private GameObject wheelDisplayPlane;

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

        if (bettingMaster == null || wheelManager == null || ballController == null)
        {
            Debug.LogWarning("Roulette bridge is missing references.");
            return;
        }

        if (!bettingMaster.HasAnyBetsPlaced())
        {
            Debug.Log("No bets placed.");
            return;
        }

        roundInProgress = true;
        wheelDisplayPlane.SetActive(true);
        bettingMaster.LockBetting();
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