using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button : MonoBehaviour {

	public GameObject defenderPrefab;

	private button[] buttonArray;
	public static GameObject slectedDefender;
	private Text costText;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = Color.black;
		buttonArray = GameObject.FindObjectsOfType<button> ();

		costText = GetComponentInChildren<Text> ();
		if (!costText) {
			Debug.Log (name + "has no cost text");
		}

		costText.text = defenderPrefab.GetComponent<Defenders> ().starCost.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		//print(name + "pressed");

		foreach (button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		slectedDefender = defenderPrefab;


	}
}
