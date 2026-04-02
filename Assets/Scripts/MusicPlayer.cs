using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    void Awake()
    {
        // Singleton pattern to prevent multiple audio managers
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object alive
        }
        else
        {
            Destroy(gameObject); // Destroys duplicates
        }
    }
}
