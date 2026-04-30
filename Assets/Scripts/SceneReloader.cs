using UnityEngine;
using UnityEngine.SceneManagement; // Make sure to include this namespace

public class SceneReloader : MonoBehaviour
{
    // Public method to be called by the button's On Click event
    public void RestartCurrentScene()
    {
        // Reload the currently active scene by its build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        // Alternatively, you can use the scene's name:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Optional: Ensure time scale is normal if it was modified (e.g., paused on game over)
        Time.timeScale = 1f;
    }
}
