using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Defenders))]
public class Butler : MonoBehaviour {


	private Animator anim;
	private Defenders defender;

	private GameObject obj;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		defender = GetComponent<Defenders> ();
	}

	// Update is called once per frame
	void Update () {
		if (obj == null) {
			anim.SetBool ("isAttacking", false);
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {

		obj = collider.gameObject;

		if (!obj.GetComponent<Attackers> ()) {
			return;
		} 
			
		anim.SetBool ("isAttacking", true);
		defender.Attack (obj);
	}

}
