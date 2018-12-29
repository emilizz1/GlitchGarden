using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] GameObject winLabel;

    private float levelSeconds ;
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;

    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        winLabel.SetActive(false);
        levelSeconds = FindObjectOfType<Spawner>().GetLevelTime();
    }

    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel && FindObjectsOfType<Attacker>().Length < 1 && !FindObjectOfType<LevelLives>().levelLost)
        {
            DestroyAllTaggedObjects();
            audioSource.Play();
            winLabel.SetActive(true);
            FindObjectOfType<LevelManager>().LevelWon();
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
}
