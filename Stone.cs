﻿using UnityEngine;
using System.Collections; 

public class Stone : MonoBehaviour {

	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D collider) {
		Attackers attacker = collider.gameObject.GetComponent<Attackers> ();

		if (attacker) {
			animator.SetTrigger ("underAttackTrigger");
		}
	}
}
