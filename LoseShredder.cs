using UnityEngine;
using System.Collections;

public class LoseShredder : MonoBehaviour {

	private LevelManagement levelManager;
	private GameTimer gameTimer;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManagement> ();
		gameTimer = GameObject.FindObjectOfType<GameTimer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D () {
		if (!gameTimer.isEndOfLevel) {
			levelManager.LoadLevel ("03b Lose");
		}
	}
}
