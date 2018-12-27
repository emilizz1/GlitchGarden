using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLives : MonoBehaviour
{
    [SerializeField] int levelLives = 2;

    AudioSource audioSource;
    GameObject winLAbel;
    Text text;

	void Start ()
    {
        text = GetComponent<Text>();
        text.text = levelLives.ToString();
        audioSource = GetComponent<AudioSource>();
        winLAbel = GameObject.Find("You win"); //TODO serialize
    }
    
	void RemoveLife()
    {
        levelLives -= 1;
        text.text = levelLives.ToString();
        if (levelLives == 0)
        {
            DestroyAllTaggedObjects();
            audioSource.Play();
            winLAbel.SetActive(true);
            FindObjectOfType<LevelManager>().LevelLost();
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
