using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	void Spawn (GameObject myGameObject) {
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;

		//print (transform.position);
		//print (myAttacker.transform.position);
	}

	bool isTimeToSpawn (GameObject attackerGameObject) {
		Attackers attacker = attackerGameObject.GetComponent<Attackers> ();

		float meanSpawnDelay = attacker.seenEverySecond;
		float spawnsPerSecnod = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.Log ("Spawn rate capped by frame rate");
		}

		float threshold = spawnsPerSecnod * Time.deltaTime / 15;

		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}
	}
}
