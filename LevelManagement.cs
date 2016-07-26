using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start () {
		if (autoLoadNextLevelAfter == 0) {
			Debug.Log (" Not autoload");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name) {
		Debug.Log ("Level load requested for " + name);
		SceneManager.LoadScene(name);
	}

	public void ReloadLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //new load level
	}

	public void QuitRequest() {
		Debug.Log("I wanna quit!"); 
		Application.Quit ();
	}

	public void LoadNextLevel () {
		print (SceneManager.GetActiveScene ().buildIndex);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
		
}


