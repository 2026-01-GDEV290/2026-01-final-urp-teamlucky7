using UnityEngine;
using UnityEngine.SceneManagement; // Essential for scene control

public class BackToCasino : MonoBehaviour
{
    // Function to load a scene by its name
    public void LoadByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Function to load a scene by its build index
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
