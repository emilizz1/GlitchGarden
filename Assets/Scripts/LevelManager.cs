using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int MainMenuBuildIndex = 3;

    bool levelWon = false;
    bool levelLost = false;

    public float autoLoadNextLevelAfter;

    private void Awake()
    {
        int levelManagerCount = FindObjectsOfType<LevelManager>().Length;
        if(levelManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        if (autoLoadNextLevelAfter > 0) {
            Invoke("LoadMainMenu", autoLoadNextLevelAfter);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        levelWon = false;
        levelLost = false;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuBuildIndex);
    }

    public void LevelWon()
    {
        levelWon = true;
        Invoke("LoadNextLevel", 3f);
    }

    public void LevelLost()
    {
        levelLost = true;
        Invoke("LoadMainMenu", 3f);
    }
}
