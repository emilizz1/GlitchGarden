﻿using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public AudioClip [] levelMusicChangeArray;

	private AudioSource audioSource;
	
	void Awake ()
    {
		DontDestroyOnLoad (gameObject);
	}

	void Start ()
    {
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = PlayerPrefManager.GetMasterVolume ();
	}

	void OnLevelWasLoaded(int level) // TODO refactor this method
    {
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		if (thisLevelMusic)
        {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void ChangeVolume (float volume)
    {
		audioSource.volume = volume;
	}
}
