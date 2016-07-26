using UnityEngine;
using System.Collections;

public class SetStart : MonoBehaviour {

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		if (musicManager) {
			float volume = PlayerPrefsManager.GetMasterVolume ();
			musicManager.ChangeVolume (volume);
		} else {
			Debug.Log ("warning");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
