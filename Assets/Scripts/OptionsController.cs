using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
	
	public Slider VolumeSlider;
	public Slider Difficultyslider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		VolumeSlider.value = PlayerPrefManager.GetMasterVolume ();
		Difficultyslider.value = PlayerPrefManager.GetDifficulty ();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume (VolumeSlider.value);
	}
	
	public void SaveAndExit(){
		PlayerPrefManager.SetMasterVolume (VolumeSlider.value);
		PlayerPrefManager.SetDifficulty (Difficultyslider.value);
		levelManager.LoadLevel ("01a_Start");
	}

	public void SetDefault (){
		VolumeSlider.value = 0.3f;
		Difficultyslider.value = 2f;
	}
}
