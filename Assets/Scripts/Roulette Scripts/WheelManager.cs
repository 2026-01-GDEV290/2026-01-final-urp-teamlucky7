using UnityEngine;

public class WheelManager : MonoBehaviour
{
    [SerializeField] private RSpinobject wheelCenterSpinner;
    [SerializeField] private RSpinobject wheelOuterSpinner;
    [SerializeField] private RouletteBallController ball;
    [SerializeField] private Transform spinningPart;

    [SerializeField] private float centerSpinSpeed = 15f;
    [SerializeField] private float outerSpinSpeed = 0f;

    private void Start()
    {
        RandomizeRotation();

        if (wheelCenterSpinner != null)
            SetSpinnerSpeed(wheelCenterSpinner, centerSpinSpeed);

        if (wheelOuterSpinner != null)
            SetSpinnerSpeed(wheelOuterSpinner, outerSpinSpeed);
    }

    private void Update()
    {
        if (ball != null && ball.HasLanded)
        {
            Debug.Log("Winning number is: " + ball.LandedNumber);
        }
    }

    public void StartSpin()
    {
        RandomizeRotation();
        LaunchBall();
    }

    public void LaunchBall()
    {
        if (ball != null)
        {
            ball.ResetBall();
        }
    }

    public void RandomizeRotation()
    {
        if (spinningPart == null)
            return;

        float randomY = Random.Range(0f, 360f);

        Vector3 currentRotation = spinningPart.eulerAngles;
        spinningPart.eulerAngles = new Vector3(
            currentRotation.x,
            randomY,
            currentRotation.z
        );
    }

    private void SetSpinnerSpeed(RSpinobject spinner, float speed)
    {
        if (spinner != null)
        {
            spinner.spinSpeed = speed;
        }
    }
}