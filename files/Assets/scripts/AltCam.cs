using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCam : MonoBehaviour {
	public GameObject camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.name == "Character") {
			camera.GetComponent<camera> ().Change ();
		}
	}
}
