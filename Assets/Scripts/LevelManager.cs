using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int MainMenuBuildIndex = 3;

    bool levelWon = false;
    bool levelLost = false;

    public float autoLoadNextLevelAfter;

    void Start()
    {
        if (autoLoadNextLevelAfter > 0) {
            Invoke("LoadMainMenu", autoLoadNextLevelAfter);
        }
    }

    void Update()
    {
        if(levelWon && Input.GetMouseButton(0))
        {
            LoadNextLevel();
        }
        else if(levelLost && Input.GetMouseButton(0))
        {
            LoadMainMenu();
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
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

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuBuildIndex);
    }

    public void LevelWon()
    {
        levelWon = true;
    }

    public void LevelLost()
    {
        levelLost = true;
    }
}
