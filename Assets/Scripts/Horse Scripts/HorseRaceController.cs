using UnityEngine;

public class HorseRaceController : MonoBehaviour
{
    public float speed = 5f;
    public bool isRacing = false;
    private Vector3 startPosition;

    void Start() { startPosition = transform.position; }

    void Update()
    {
        if (isRacing)
        {
            // Move forward with random speed fluctuation
            float movement = Random.Range(0f, 1f) * speed * Time.deltaTime;
            transform.Translate(Vector3.forward * movement);
        }
    }

    public void ResetHorse()
    {
        transform.position = startPosition;
        isRacing = false;
    }
}
