using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    bool levelFinished = false;

    public float autoLoadNextLevelAfter;

    void Start()
    {
        if (autoLoadNextLevelAfter > 0) {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    void Update()
    {
        if(levelFinished && Input.GetMouseButton(0))
        {
            LoadNextLevel();
        }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // TODO fix
    }

    public void LevelFinished()
    {
        levelFinished = true;
    }
}
