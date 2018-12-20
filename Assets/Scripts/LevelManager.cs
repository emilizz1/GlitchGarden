using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float autoLoadNextLevelAfter;

    void Start()
    {
        if (autoLoadNextLevelAfter > 0)
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
    }

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name); //TODO change to int
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings + 1);
    }
}
