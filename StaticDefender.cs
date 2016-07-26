using UnityEngine;
using System.Collections;

public class StaticDefender : MonoBehaviour {

	private GameObject currenTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> (); 
	}

	// Update is called once per frame
	void Update () {
		if (!currenTarget) {
			animator.SetBool ("isAttacking", false);
		}
	}

	void OnTriggerEnter2D () {
		Debug.Log (name + " trigger enter");
	}





	public void StrikeCurrentTarget(float damage) {
		//Debug.Log(name + "caused damege" + damage);
		if (currenTarget) {
			Health health = currenTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (damage);
			}
		}

	}

	public void Attack (GameObject obj) {
		currenTarget = obj;
	}
}
