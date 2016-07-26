using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject defenderParent;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		defenderParent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		Vector2 pos = SnapToGrid (CalculateWorldPoint ());
		GameObject defender = button.slectedDefender;

		int defenderCost = defender.GetComponent<Defenders> ().starCost; 
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			Quaternion zeroRot = Quaternion.identity;
			GameObject newDef = Instantiate (defender, pos, zeroRot) as GameObject;

			newDef.transform.parent = defenderParent.transform;
		} else {
			Debug.Log ("insufficient stars");
		}
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);

		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPoint() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromcamera = 10f;

		Vector3 wierdTriplet = new Vector3 (mouseX, mouseY, distanceFromcamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (wierdTriplet);

		return worldPos;
	}
}
