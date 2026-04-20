using UnityEngine;
using UnityEngine.SceneManagement; // Essential for scene control

public class SceneNavigator : MonoBehaviour
{
    // Function to load a scene by its name
    //Added functionality to have it load the UI
    public void LoadByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        SceneManager.LoadScene("UiTest", LoadSceneMode.Additive);
    }

    // Function to load a scene by its build index
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
    }

    public void LoadRoulette(int sceneIndex)
    {
        SceneManager.LoadScene(4);
        SceneManager.LoadScene(5, LoadSceneMode.Additive);
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
    }
}
