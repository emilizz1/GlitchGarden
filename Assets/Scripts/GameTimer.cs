using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private float levelSeconds ;
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private GameObject winLAbel;

    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        winLAbel = GameObject.Find("You win"); //TODO serialize
        winLAbel.SetActive(false);
        levelSeconds = FindObjectOfType<Spawner>().GetLevelTime();
    }

    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel && FindObjectsOfType<Attacker>().Length < 1)
        {
            DestroyAllTaggedObjects();
            audioSource.Play();
            winLAbel.SetActive(true);
            FindObjectOfType<LevelManager>().LevelFinished();
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
