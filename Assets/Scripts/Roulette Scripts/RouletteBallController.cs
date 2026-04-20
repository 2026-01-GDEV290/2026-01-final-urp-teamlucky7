using System;
using UnityEngine;

public class RouletteBallController : MonoBehaviour
{
    public event Action<int> OnBallLanded;
    [Header("Orbit Target")]
    [SerializeField] private Transform wheelCenter;

    [Header("Starting Orbit")]
    [SerializeField] private float startRadius = 4.5f;
    [SerializeField] private float startHeight = 0.6f;
    [SerializeField] private float minStartSpeed = 6f;
    [SerializeField] private float maxStartSpeed = 10f;

    [Header("Slowdown")]
    [SerializeField] private float angularDeceleration = 0.5f;
    [SerializeField] private float minDropSpeed = 1.5f;

    [Header("Drop Inward")]
    [SerializeField] private float inwardDropSpeed = 0.5f;
    [SerializeField] private float finalRadius = 2.2f;
    [SerializeField] private float fallSpeed = 0.3f;
    [SerializeField] private float finalHeight = 0.15f;

    [Header("Motion Direction")]
    [SerializeField] private bool clockwise = true;

    private float currentRadius;
    private float currentHeight;
    private float currentAngularSpeed;
    private float angle;

    private bool isDropping = false;
    private bool hasLanded = false;

    public int LandedNumber { get; private set; } = -1;
    public bool HasLanded => hasLanded;

    private void Start()
    {
        ResetBall();
    }

    private void Update()
    {
        if (wheelCenter == null || hasLanded)
            return;

        UpdateBallMotion();
        UpdateBallPosition();
    }

    public void ResetBall()
    {
        currentRadius = startRadius;
        currentHeight = startHeight;
        currentAngularSpeed = UnityEngine.Random.Range(minStartSpeed, maxStartSpeed);
        angle = 0f;
        isDropping = false;
        hasLanded = false;
        LandedNumber = -1;

        UpdateBallPosition();
    }

    private void UpdateBallMotion()
    {
        if (!isDropping)
        {
            currentAngularSpeed -= angularDeceleration * Time.deltaTime;

            if (currentAngularSpeed <= minDropSpeed)
            {
                currentAngularSpeed = minDropSpeed;
                isDropping = true;
            }
        }
        else
        {
            currentRadius = Mathf.MoveTowards(currentRadius, finalRadius, inwardDropSpeed * Time.deltaTime);
            currentHeight = Mathf.MoveTowards(currentHeight, finalHeight, fallSpeed * Time.deltaTime);

            // optional extra slowdown while dropping
            currentAngularSpeed = Mathf.MoveTowards(currentAngularSpeed, 0.8f, 0.3f * Time.deltaTime);
        }

        float direction = clockwise ? -1f : 1f;
        angle += direction * currentAngularSpeed * Time.deltaTime;
    }

    private void UpdateBallPosition()
    {
        float x = wheelCenter.position.x + Mathf.Cos(angle) * currentRadius;
        float z = wheelCenter.position.z + Mathf.Sin(angle) * currentRadius;
        float y = wheelCenter.position.y + currentHeight;

        transform.position = new Vector3(x, y, z);
    }

    public void SetLandedNumber(int number, Transform slotTransform)
    {
        if (hasLanded)
            return;

        hasLanded = true;
        LandedNumber = number;

        // Snap position to slot
        transform.position = slotTransform.position;

        // Optional: match rotation
        transform.rotation = slotTransform.rotation;

        // Parent to slot
        transform.SetParent(slotTransform);

        // Stop all motion
        currentAngularSpeed = 0f;

        //Send to betting scripts
        OnBallLanded?.Invoke(number);

        Debug.Log("Ball landed on: " + number);
    }
}