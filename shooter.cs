using UnityEngine;
using System.Collections;

public class shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner laneSpawner;

	// Use this for initialization
	void Start () {
		projectileParent = GameObject.Find ("Projectiles");
		animator = GameObject.FindObjectOfType<Animator> ();

		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}

		setMyLaneSpawner ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAttackerAhead ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	void setMyLaneSpawner () {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();
		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				laneSpawner = spawner;
				//print (spawner.transform.position);
				return;
			}
		}
		Debug.LogError (name + "cant find spawner");
	}

	bool isAttackerAhead () {

		//stop if no attackers are in lane
		if (laneSpawner.transform.childCount <= 0) {
			return false;
		}

		//check if attackers are ahead
		foreach (Transform attacker in laneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		//attackers in lane but behind
		return false;
	}

	private void Fire() {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
