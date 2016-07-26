using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] LevelMusicChangeArray;

	public AudioSource audioSource;

	//private GameTimer gameTimer;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		//gameTimer = GameObject.FindObjectOfType<GameTimer> ();
		audioSource = GetComponent<AudioSource> ();
	} 
	
	// Update is called once per frame
	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = LevelMusicChangeArray [level];

		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	public void ChangeVolume (float volume) {
		audioSource.volume = volume;
	}
}
