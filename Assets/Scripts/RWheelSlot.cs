using UnityEngine;

public class RWheelSlot : MonoBehaviour
{
    [SerializeField] private int slotNumber;

    private void OnTriggerEnter(Collider other)
    {
        RouletteBallController ball = other.GetComponent<RouletteBallController>();

        if (ball != null && !ball.HasLanded)
        {
            ball.SetLandedNumber(slotNumber, transform);
        }
    }
}

