using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	[SerializeField] GameObject[] attackerPrefabArray;
    [SerializeField] float[] attackerSpawnTime;
    [SerializeField] GameObject[] spawnLanes;

    bool playing = true;

    void Start()
    {
        StartCoroutine(Spawing());
    }

    IEnumerator Spawing()
    {
        int currentAttacker = 0;
        while (playing)
        {
            if (attackerPrefabArray[currentAttacker])
            {
                yield return new WaitForSecondsRealtime(attackerSpawnTime[currentAttacker]);
                Spawn(attackerPrefabArray[currentAttacker]);
                currentAttacker++;
            }
            else
            {
                playing = false;
            }
        }
    }

	void Spawn (GameObject myGameObject)
    {
        GameObject spawningLane = spawnLanes[Random.Range(0, spawnLanes.Length)];
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = spawningLane.transform;
        myAttacker.transform.position = spawningLane.transform.position;
    }

    public float GetLevelTime()
    {
        float levelTime = 0;
        foreach(float time in attackerSpawnTime)
        {
            levelTime += time;
        }
        return levelTime;
    }

    public void StoppedPlaying()
    {
        playing = false;
    }
}
