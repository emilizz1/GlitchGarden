using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] int[] menuBuildIndex;
    [SerializeField] int[] gameBuildIndex;
    [SerializeField] AudioClip[] mouseClick;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameplayMusic;

    bool currentlyPlayingMenuMusic = false;

	private AudioSource audioSource;
	
	void Awake ()
    {
		DontDestroyOnLoad (gameObject);
	}

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    void Start ()
    {
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = PlayerPrefManager.GetMasterVolume ();
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(mouseClick[Random.Range(0, mouseClick.Length)], Camera.main.transform.position);
        }
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!currentlyPlayingMenuMusic)
        {
            foreach (int i in menuBuildIndex)
            {
                if (i == scene.buildIndex)
                {
                    audioSource.clip = menuMusic;
                    audioSource.loop = true;
                    audioSource.Play();
                    currentlyPlayingMenuMusic = true;
                }
            }
        }
        else
        {
            foreach (int i in gameBuildIndex)
            {
                if (i == scene.buildIndex)
                {
                    audioSource.clip = gameplayMusic;
                    audioSource.loop = true;
                    audioSource.Play();
                    currentlyPlayingMenuMusic = false;
                }
            }
        }
    }

    public void ChangeVolume (float volume)
    {
		audioSource.volume = volume;
	}
}
