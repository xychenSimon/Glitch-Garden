using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;

	private Slider slider;
	private LevelManagement levelManager;
	private AudioSource audiosource;
	private GameObject winLabel;
	public bool isEndOfLevel = false;

	private MusicManager musicManager;
	//private AudioSource audio_;


	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		audiosource = GetComponent <AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManagement> ();

		musicManager = GameObject.FindObjectOfType<MusicManager> ();

		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.Log ("please create win object");
		} 

		winLabel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//slider.value = Time.timeSinceLevelLoad / levelSeconds;

		if (isTime()/*Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel*/) {

			//print ("level is over");
			AudioClip lv_music = musicManager.LevelMusicChangeArray[SceneManager.GetActiveScene().buildIndex];
			if (lv_music) {
				print (lv_music + "found source");
				musicManager.audioSource.clip = lv_music;
				musicManager.audioSource.Stop ();
			}

			isEndOfLevel = true;
			audiosource.Play ();
			winLabel.SetActive (true);
			Invoke ("LoadNextLevel", audiosource.clip.length);

		}
	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel ();
	}
		
	// idk about this
	public bool isTime() {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
			return true;
		}

		return false;
	}
}
