using UnityEngine;

public class RSpinobject : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] public float spinSpeed = 20f;

    private void Update()
    {
        transform.Rotate(rotationAxis.normalized * spinSpeed * Time.deltaTime, Space.Self);
    }
}