using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (Rigidbody2D))]
public class Attackers : MonoBehaviour {

	[Range (-1f, 15f)] public float currentSpeed;

	private GameObject currenTarget;
	private Animator animator;
	public float seenEverySecond;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidBody.isKinematic = true;

		animator = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currenTarget) {
			animator.SetBool ("isAttacking", false);
		}

		print (button.slectedDefender);
	}

	void OnTriggerEnter2D () {
		//Debug.Log (name + " trigger enter");
	}

	public void setSpeed (float speed) {
		currentSpeed = speed;
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
