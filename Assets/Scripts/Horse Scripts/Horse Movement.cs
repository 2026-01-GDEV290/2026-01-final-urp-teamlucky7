using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    public float minSpeed = 5f;
    public float maxSpeed = 10f;
    private float currentSpeed;
    private AudioSource audioSource;
    private float minPitch = 0.8f;
    private float maxPitch = 1.2f;
    private bool isRacing = false;

    // Call this from your UI Button to start the race
    public void StartRace()
    {
        audioSource = GetComponent<AudioSource>();
        isRacing = true;
        // Randomize speed at the start of the race
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        if (isRacing)
        {
            // Move the horse forward relative to its own Z-axis
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.Play();

            // Optional: Randomize speed slightly during the race for realism
            if (Random.value > 0.98f)
            {
                currentSpeed = Random.Range(minSpeed, maxSpeed);
            }
        }
    }

    public void StopRace() => isRacing = false;
}
