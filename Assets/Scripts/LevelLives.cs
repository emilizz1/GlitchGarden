using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLives : MonoBehaviour
{
    [SerializeField] int levelLives = 2;
    [SerializeField] GameObject loseLabel;

    public bool levelLost = false;

    AudioSource audioSource;
    Text text;

	void Start ()
    {
        text = GetComponent<Text>();
        text.text = levelLives.ToString();
        audioSource = GetComponent<AudioSource>();
        loseLabel.SetActive(false);
    }
    
	public void RemoveLife()
    {
        levelLives -= 1;
        text.text = levelLives.ToString();
        if (levelLives == 0 && !levelLost)
        {
            DestroyAllTaggedObjects();
            FindObjectOfType<Spawner>().StoppedPlaying();
            //audioSource.Play();
            loseLabel.SetActive(true);
            FindObjectOfType<LevelManager>().LevelLost();
            levelLost = true;
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
