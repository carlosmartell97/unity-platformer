using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plate : MonoBehaviour {
	bool move;
	public bool end;
	public GameObject wall;
	public GameObject finisher,winT;
	// Use this for initialization
	void Start () {
		if (end) {
			winT.GetComponent<Text> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!end) {
			if (move && wall.transform.position.y <= 30) {
				wall.transform.Translate (0, 0.1f, 0);
			} else if (wall.transform.position.y >= 19) {
				wall.transform.Translate (0, -0.05f, 0);
			}
		}
	}

	void OnTriggerEnter(Collider c){
		if (!end && c.gameObject.name == "Character") {
			move = true;
		}
		if (end && c.gameObject.name == "Character") { 
			winT.GetComponent<Text> ().enabled = true;
			finisher.GetComponent<finisher> ().Finish ();
		}
	}

	void OnTriggerExit(Collider c){
		if (c.gameObject.name == "Character") {
			move = false;
		}
	}
}
