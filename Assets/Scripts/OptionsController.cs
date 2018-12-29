using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
	public Slider VolumeSlider;
	public Slider Difficultyslider;
	
	private MusicManager musicManager;
	
	void Start ()
    {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		VolumeSlider.value = PlayerPrefManager.GetMasterVolume ();
		Difficultyslider.value = PlayerPrefManager.GetDifficulty ();
	}
	
	void Update ()
    {
		musicManager.ChangeVolume (VolumeSlider.value);
	}
	
	public void SaveAndExit()
    {
		PlayerPrefManager.SetMasterVolume (VolumeSlider.value);
		PlayerPrefManager.SetDifficulty (Difficultyslider.value);
		FindObjectOfType<LevelManager>().LoadMainMenu();
	}

	public void SetDefault ()
    {
		VolumeSlider.value = 0.3f;
		Difficultyslider.value = 2f;
	}
}
