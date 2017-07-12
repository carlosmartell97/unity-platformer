using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate1 : MonoBehaviour {
	bool move;
	int side;
	public GameObject wall;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (move && wall.transform.position.y <= 30) {
			wall.transform.Translate (-0.1f,0,0);
		} else if (wall.transform.position.y >= 23) {
			wall.transform.Translate (0.05f,0,0);
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.name == "Character") {
			move = true;
		}
	}

	void OnTriggerExit(Collider c){
		if (c.gameObject.name == "Character") {
			move = false;
		}
	}
}
