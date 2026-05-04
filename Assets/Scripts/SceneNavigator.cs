using UnityEngine;
using UnityEngine.SceneManagement; 

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
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void LoadCharacterSelect(int sceneIndex)
    {
        
        SceneManager.LoadScene(7);
    }

    public void LoadRoulette(int sceneIndex)
    {
        
        SceneManager.LoadScene(5);
        SceneManager.LoadScene(6, LoadSceneMode.Additive);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void LoadNextday(int sceneIndex)
    {
        
        SceneManager.LoadScene(2);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
