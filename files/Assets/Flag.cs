using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {
	
	public GameObject wall;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.name == "endpoint") {
			Destroy (gameObject);
			Destroy (wall);
		}
	}
}
