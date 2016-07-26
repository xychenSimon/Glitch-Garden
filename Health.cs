﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 50f;

	public void DealDamage (float damage) {
		health -= damage;
		if (health < 0) {
			//optionally trigger animation
			DestroyObject();
		}
	}

	public void DestroyObject() {
		Destroy (gameObject);
	}
}
