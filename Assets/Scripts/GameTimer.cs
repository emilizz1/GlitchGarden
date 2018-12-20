using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float levelSeconds = 100;

    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLAbel;

    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLAbel = GameObject.Find("You win");
        winLAbel.SetActive(false);
    }

    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            DestroyAllTaggedObjects();
            audioSource.Play();
            winLAbel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
        }
    }

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach (GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
