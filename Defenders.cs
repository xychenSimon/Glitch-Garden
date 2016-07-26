using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	private GameObject currenTarget;
	private StarDisplay starDisplay;

	public int starCost = 100;


	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D () {
		//Debug.Log (name + " trigger enter");
	}

	public void AddStars (int amount) {
		starDisplay.AddStars (amount);
	}



	//=================================================
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
